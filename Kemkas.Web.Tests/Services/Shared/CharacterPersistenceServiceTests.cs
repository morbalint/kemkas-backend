using Kemkas.Web.Db;
using Kemkas.Web.Db.Enums;
using Kemkas.Web.Db.Models;
using Kemkas.Web.Services.Identity;
using Kemkas.Web.Services.Shared;
using Microsoft.EntityFrameworkCore;

namespace Kemkas.Web.Tests.Services.Shared;

public class CharacterPersistenceServiceTests
{
    [Fact]
    public async Task StoreNewCharacter1E_SetsOwnerAndPublicFlag()
    {
        await using var dbContext = CreateDbContext();
        var currentUserService = new FakeCurrentUserService(new ApplicationUser { Id = 42 });
        var sut = new CharacterPersistenceService(dbContext, currentUserService);

        var id = await sut.StoreNewCharacter1E(CreateV1Character(id: Guid.NewGuid()), isPublic: true);

        var saved = await dbContext.Karakterek.SingleAsync(x => x.Id == id);
        Assert.Equal(42, saved.OwnerUserId);
        Assert.True(saved.IsPublic);
    }

    [Fact]
    public async Task StoreNewCharacter2E_SetsOwnerAndPublicFlag()
    {
        await using var dbContext = CreateDbContext();
        var currentUserService = new FakeCurrentUserService(new ApplicationUser { Id = 99 });
        var sut = new CharacterPersistenceService(dbContext, currentUserService);

        var id = await sut.StoreNewCharacter2E(CreateV2Character(id: Guid.NewGuid()), isPublic: true);

        var saved = await dbContext.Karakterek2E.SingleAsync(x => x.Id == id);
        Assert.Equal(99, saved.OwnerUserId);
        Assert.True(saved.IsPublic);
    }

    [Fact]
    public async Task GetCharacter1EById_PrivateCharacterFromDifferentOwner_ReturnsNull()
    {
        await using var dbContext = CreateDbContext();
        var id = Guid.NewGuid();
        dbContext.Karakterek.Add(CreateV1Character(id, ownerUserId: 10, isPublic: false));
        await dbContext.SaveChangesAsync();

        var sut = new CharacterPersistenceService(dbContext, new FakeCurrentUserService(new ApplicationUser { Id = 20 }));

        var result = await sut.GetCharacter1EById(id);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetCharacter2EById_PrivateCharacterFromOwner_ReturnsEntity()
    {
        await using var dbContext = CreateDbContext();
        var id = Guid.NewGuid();
        dbContext.Karakterek2E.Add(CreateV2Character(id, ownerUserId: 10, isPublic: false));
        await dbContext.SaveChangesAsync();

        var sut = new CharacterPersistenceService(dbContext, new FakeCurrentUserService(new ApplicationUser { Id = 10 }));

        var result = await sut.GetCharacter2EById(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetCharacter2EById_PublicCharacter_ReturnsEntityForAnonymousUser()
    {
        await using var dbContext = CreateDbContext();
        var id = Guid.NewGuid();
        dbContext.Karakterek2E.Add(CreateV2Character(id, ownerUserId: 10, isPublic: true));
        await dbContext.SaveChangesAsync();

        var sut = new CharacterPersistenceService(dbContext, new FakeCurrentUserService(null));

        var result = await sut.GetCharacter2EById(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetAllCharactersOfUser_NoCurrentUser_ReturnsEmptyList()
    {
        await using var dbContext = CreateDbContext();
        var sut = new CharacterPersistenceService(dbContext, new FakeCurrentUserService(null));

        var result = await sut.GetAllCharactersOfUser();

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAllCharactersOfUser_ReturnsOnlyCurrentUsersCharactersFromBothEditions()
    {
        await using var dbContext = CreateDbContext();
        const int userId = 7;

        dbContext.Karakterek.Add(CreateV1Character(Guid.NewGuid(), ownerUserId: userId, name: "V1 Hero"));
        dbContext.Karakterek.Add(CreateV1Character(Guid.NewGuid(), ownerUserId: 999, name: "Other V1"));

        var v2Id = Guid.NewGuid();
        dbContext.Karakterek2E.Add(CreateV2Character(v2Id, ownerUserId: userId, name: "V2 Hero"));
        dbContext.Szintlepesek2E.Add(new V2Szintlepes
        {
            Id = Guid.NewGuid(),
            KarakterId = v2Id,
            KarakterSzint = 1,
            Osztaly = Osztaly2E.Varazslo,
            HpRoll = 4,
            Karakter = null!
        });
        dbContext.Karakterek2E.Add(CreateV2Character(Guid.NewGuid(), ownerUserId: 999, name: "Other V2"));

        await dbContext.SaveChangesAsync();

        var sut = new CharacterPersistenceService(dbContext, new FakeCurrentUserService(new ApplicationUser { Id = userId }));

        var result = await sut.GetAllCharactersOfUser();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, x => x.Name == "V1 Hero" && x.Edition == "1e");
        Assert.Contains(result, x => x.Name == "V2 Hero" && x.Edition == "2e" && x.Osztaly == "o_2e_varazslo");
        Assert.DoesNotContain(result, x => x.Name.StartsWith("Other"));
    }

    private static ApplicationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"kemkas-tests-{Guid.NewGuid()}")
            .Options;

        return new ApplicationDbContext(options);
    }

    private static V1Karakter CreateV1Character(
        Guid? id = null,
        int? ownerUserId = null,
        bool isPublic = false,
        string name = "V1")
    {
        return new V1Karakter
        {
            Id = id ?? Guid.Empty,
            OwnerUserId = ownerUserId,
            IsPublic = isPublic,
            Nev = name,
            Faj = Faj1E.Ember,
            Osztaly = Osztaly1E.Harcos,
            Jellem = Jellem.Semleges,
            Ero = 10,
            Ugyesseg = 10,
            Egeszseg = 10,
            Intelligencia = 10,
            Bolcsesseg = 10,
            Karizma = 10,
            KarakterKepzettsegek = new List<V1KarakterKepzettseg>(),
            Szintlepesek = new List<V1Szintlepes>(),
            Felszereles = new List<V1Felszereles>()
        };
    }

    private static V2Karakter CreateV2Character(
        Guid? id = null,
        int? ownerUserId = null,
        bool isPublic = false,
        string name = "V2")
    {
        return new V2Karakter
        {
            Id = id ?? Guid.Empty,
            OwnerUserId = ownerUserId,
            IsPublic = isPublic,
            Nev = name,
            Faj = Faj2E.Ember,
            Jellem = Jellem.Semleges,
            Ero = 10,
            Ugyesseg = 10,
            Egeszseg = 10,
            Intelligencia = 10,
            Bolcsesseg = 10,
            Karizma = 10,
            KarakterKepzettsegek = new List<V2KarakterKepzettseg>(),
            Szintlepesek = new List<V2Szintlepes>(),
            Felszereles = new List<V2Felszereles>(),
            Varazslatok = new HashSet<V2KarakterVarazslat>()
        };
    }

    private sealed class FakeCurrentUserService(ApplicationUser? user) : ICurrentUserService
    {
        public Task<ApplicationUser?> GetCurrentUser() => Task.FromResult(user);

        public Task<ApplicationUser> GetCurrentUserOrThrow() =>
            user is null
                ? throw new InvalidOperationException("no current user")
                : Task.FromResult(user);
    }
}

