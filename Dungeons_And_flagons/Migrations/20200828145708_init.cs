using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dungeons_And_Flagons.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Permission = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Spellslots = table.Column<int>(nullable: false),
                    Source = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classes_Sources_Source",
                        column: x => x.Source,
                        principalTable: "Sources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    CastingTime = table.Column<string>(nullable: true),
                    Range = table.Column<string>(nullable: true),
                    Components = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Source = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spells_Sources_Source",
                        column: x => x.Source,
                        principalTable: "Sources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subraces",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainRace = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Spellcasting = table.Column<bool>(nullable: false),
                    Source = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subraces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subraces_Sources_BookID",
                        column: x => x.BookID,
                        principalTable: "Sources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subclasses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Classe = table.Column<int>(nullable: false),
                    Source = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subclasses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subclasses_Classes_Classe",
                        column: x => x.Classe,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subclasses_Sources_Source",
                        column: x => x.Source,
                        principalTable: "Sources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClasseSpells",
                columns: table => new
                {
                    ClasseID = table.Column<int>(nullable: false),
                    SpellID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseSpells", x => new { x.ClasseID, x.SpellID });
                    table.ForeignKey(
                        name: "FK_ClasseSpells_Classes_ClasseID",
                        column: x => x.ClasseID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClasseSpells_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubracesSpell",
                columns: table => new
                {
                    SubraceID = table.Column<int>(nullable: false),
                    SpellID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubracesSpell", x => new { x.SubraceID, x.SpellID });
                    table.ForeignKey(
                        name: "FK_SubracesSpell_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubracesSpell_Subraces_SubraceID",
                        column: x => x.SubraceID,
                        principalTable: "Subraces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubclassSpell",
                columns: table => new
                {
                    SubclassID = table.Column<int>(nullable: false),
                    SpellID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubclassSpell", x => new { x.SubclassID, x.SpellID });
                    table.ForeignKey(
                        name: "FK_SubclassSpell_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubclassSpell_Subclasses_SubclassID",
                        column: x => x.SubclassID,
                        principalTable: "Subclasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "ID", "Category", "Name", "Path", "Permission", "Summary" },
                values: new object[,]
                {
                    { 1, "Content", "Basic Rules", "./Books/BasicRules.pdf", 3, "Basic Set of rules to start on your adventure" },
                    { 2, "Content", "Player's Handbook", "./Books/PHB.pdf", 3, "The Player’s Handbook is the essential reference for every Dungeons & Dragons roleplayer. It contains rules for character creation and advancement, backgrounds and skills,exploration and combat, equipment, spells, and much more. Use this book to create exciting characters from among the most iconic D&D races and classes. " },
                    { 3, "Adventure", "Sword Coast Adventurer’s guide", "./Books/Scag", 3, "A of Faerûn that comprises shining paragons of civilization and culture, perilous locales fraught with dread and evil, and encompassing them all, a wilderness that offers every explorer vast opportunity and simultaneously promises great danger. " }
                });

            migrationBuilder.InsertData(
                table: "Subraces",
                columns: new[] { "ID", "BookID", "Description", "Features", "MainRace", "Name", "Source", "Spellcasting" },
                values: new object[,]
                {
                    { 1, null, "In the reckonings of most worlds,humans are the youngest of the common races,late to arrive on the world scene and short - lived in comparison to dwarves,elves,an d dragons.Perhaps it is because of their shorter lives that they strive to achieve as much as they can in the years they are given.Or maybe they feel they have something to prove to the elder races,and that’s why they build their mighty empires on the foundation of conquest and trade.Whatever drives them,humans are the innovators,the achievers,and the pioneers of the worlds.", "Increases all ability Scores by 1,your base walking speed is 30 feet,you can speak,read and write common and one language of your choice", "Human", "Regular", 1, false },
                    { 2, null, "As a wood elf, you have keen senses and intuition, and your fleet feet carry you quickly and stealthily through your native forests.This category includes the wild elves(grugach) of Greyhawk and the Kagonesti of Dragonlance, as well as the races called wood elves in Greyhawk and the Forgotten Realms.In Faerûn, wood elves(also called wild elves, green elves, or forest elves) are reclusive and distrusting of non - elves.", " Your Dexterity increases by 2 and your wisdom increases by 1, your base walking speed is 35 feet, You have darkvision, proficiency with Perception Skill, Advantage against being Charmed, and magic can’t put you to sleep, Trance, you dont sleep you meditate for 4 hours and gain the beneficts of a long rest, You can speak, read, write common and elvish.", "Elf", "Wood Elf", 2, false },
                    { 3, null, "As a Lightfoot Halfling, you can easily hide from notice, even using other people as cover.You’re inclined to be affable and get along well with others. Lightfoots are more prone to wanderlust than other Halflings, and often dwell alongside other races or take up a nomadic life.", "Your Dexterity increases by 2, your Charisma increases by 1, As a Halfling your size is Small, your base walking speed is 25 feet, you are Lucky, whenever you roll a 1 on the d20 for na attack roll, ability check or Saving throw you can reroll the die, Brave, you have advantage against being Frightened. Nimbleness, you can move through the space of a creature one size bigger than you.", "Halfling", "Lightfoot", 2, false },
                    { 4, null, "Physically similar to other dwarves in some ways, duergar are wiry and lean, with black eyes and bald heads, with the males growing long, unkempt, gray beards. Duergar value toil above all else. Showing emotions other than grim determination or wrath is frowned on in their culture, but they can sometimes seem joyful when at work. They have the typical dwarven appreciation for order, tradition, and impeccable craftsmanship, but their goods are purely utilitarian, disdaining aesthetic or artistic value.", "Your Consitution Increases by 2 , and your strenght by 1, your base walking speed is 25 feet. Superior Darkvision, your darkvision has a radius of 120 feet.You have advantage on on Saving Throws agains’t poison and you have Resistance against poison Damage. Sunlight Sensitivity, you have disadvantage on attack rolls and perception checks that rely on sight when you are under direct sunlight. You can read,write,and speak common,swarvish and undercommon", "Dwarf", "Duergar", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Spells",
                columns: new[] { "ID", "CastingTime", "Components", "Description", "Duration", "Level", "Name", "Range", "School", "Source" },
                values: new object[,]
                {
                    { 1, "1 Action", "V", "Choose one creature that you can see within range.The target begins a comic dance in place: shuffling, tapping its feet, and capering for the duration.Creatures that can't be charmed are immune to this spell.A dancing creature must use all its movement to dance without leaving its space and has disadvantage on Dexterity saving throws and attack rolls. While the target is affected by this spell, other creatures have advantage on attack rolls against it.As an action, a dancing creature makes a Wisdom saving throw to regain control of itself.On a successful save, the spell ends.", "Concentration 1 Minute", 6, "Otto's Irresistible Dance", "30 ft", "Enchantment", 1 },
                    { 2, "1 Action", "V,S,M - (a lodestone and a pinch of dust)", "A thin green ray springs from your pointing finger to a target that you can see within range.The target can be a creature, an object, or a creation of magical force, such as the wall created by wall of force.A creature targeted by this spell must make a Dexterity saving throw. On a failed save, the target takes 10d6 + 40 force damage. The target is disintegrated if this damage leaves it with 0 hit points.A disintegrated creature and everything it is wearing and carrying, except magic items, are reduced to a pile of fine gray dust.The creature can be restored to life only by means of a true resurrection or a wish spell.This spell automatically disintegrates a Large or smaller nonmagical object or a creation of magical force.If the target is a Huge or larger object or creation of force, this spell disintegrates a 10-foot- cube portion of it. A magic item is unaffected by this spell.At Higher Levels.When you cast this spell using a spell slot of 7th level or higher, the damage increases by 3d6 for each slot level above 6th.", "Instantaneou", 6, "Disintegrate", "60 ft", "Transmutation", 1 },
                    { 3, "1 Action", "V", "Each object in a 20-foot cube within range is outlined in blue, green, or violet light(your choice). Any creature in the area when the spell is cast is also outlined in light if it fails a Dexterity saving throw. For the duration, objects and affected creatures shed dim light in a 10-foot radius.Any attack roll against an affected creature or object has advantage if the attacker can see it, and the affected creature or object can't benefit from being invisible.", "Concentration 1 Minute", 1, "Fearie Fire", "60 ft /20 ft Square", "Evocation", 1 },
                    { 4, "1 Action", "V,S,M - (a tiny ball of bat guano and sulfur)", "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one.The fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried.”", "Instantaneous", 3, "Fire Ball", "150 ft /20 ft Square", "Evocation", 1 },
                    { 5, "1 Action", "V,S,M - (a pinch of powdered iron)", "You cause a creature or an object you can see within range to grow larger or smaller for the duration. Choose either a creature or an object that is neither worn nor carried. If the target is unwilling, it can make a Constitution saving throw. On a success, the spell has no effect.If the target is a creature, everything it is wearing and carrying changes size with it. Any item dropped by an affected creature returns to normal size at once.Enlarge. The target's size doubles in all dimensions, and its weight is multiplied by eight. This growth increases its size by one category-- from Medium to Large, for example. If there isn't enough room for the target to double its size, the creature or object attains the maximum possible size in the space available. Until the spell ends, the target also has advantage on Strength checks and Strength saving throws. The target's weapons also grow to match its new size. While these weapons are enlarged, the target's attacks with them deal 1d4 extra damage.Reduce. The target's size is halved in all dimensions, and its weight is reduced to one-eighth of normal. This reduction decreases its size by one category--from Medium to Small, for example. Until the spell ends, the target also has disadvantage on Strength checks and Strength saving throws. The target's weapons also shrink to match its new size. While these weapons are reduced, the target's attacks with them deal 1d4 less damage (this can't reduce the damage below 1).", "Concentration 1 Minute", 2, "Enlarge/Reduce", "30 ft", "Transmutation", 1 },
                    { 6, "1 Action", "V", "Wish is the mightiest spell a mortal creature can cast. By simply speaking aloud, you can alter the very foundations of reality in accord with your desires.  the basic use of this spell is to duplicate any other spell of 8th level or lower. You don't need to meet any requirements in that spell, including costly components. The spell simply takes effect.Alternatively, you can create one of the following effects of your choice:You create one object of up to 25,000 gp in value that isn't a magic item. The object can be no more than 300 feet in any dimension, and it appears in an unoccupied space you can see on the ground.You allow up to twenty creatures that you can see to regain all hit points, and you end all effects on them described in the greater restoration spell.You grant up to ten creatures that you can see resistance to a damage type you choose.You grant up to ten creatures you can see immunity to a single spell or other magical effect for 8 hours. For instance, you could make yourself and all your companions immune to a lich's life drain attack.You undo a single recent event by forcing a reroll of any roll made within the last round (including your last turn). Reality reshapes itself to accommodate the new result. For example, a wish spell could undo an opponent's successful save, a foe's critical hit, or a friend's failed save. You can force the reroll to be made with advantage or disadvantage, and you can choose whether to use the reroll or the original roll.You might be able to achieve something beyond the scope of the above examples. State your wish to the GM as precisely as possible. The GM has great latitude in ruling what occurs in such an instance; the greater the wish, the greater the likelihood that something goes wrong. This spell might simply fail, the effect you desire might only be partly achieved, or you might suffer some unforeseen consequence as a result of how you worded the wish. For example, wishing that a villain were dead might propel you forward in time to a period when that villain is no longer alive, effectively removing you from the game. Similarly, wishing for a legendary magic item or artifact might instantly transport you to the presence of the item's current owner.The stress of casting this spell to produce any effect other than duplicating another spell weakens you. After enduring that stress, each time you cast a spell until you finish a long rest, you take 1d10 necrotic damage per level of that spell. This damage can't be reduced or prevented in any way. In addition, your Strength drops to 3, if it isn't 3 or lower already, for 2d4 days. For each of those days that you spend resting and doing nothing more than light activity, your remaining recovery time decreases by 2 days. Finally, there is a 33 percent chance that you are unable to cast wish ever again if you suffer this stress.", "Instantaneous", 9, "Wish", "Self", "Conjuration", 1 },
                    { 7, "1 Action", "V,S,M - (an eyelash encased in gum arabic)", "A creature you touch becomes invisible until the spell ends. Anything the target is wearing or carrying is invisible as long as it is on the target's person. The spell ends for a target that attacks or casts a spell.At Higher Levels. When you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd.", "Concentration 1 Hour", 2, "Invisibility", "Touch", "Illusion", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubracesSpell",
                columns: new[] { "SubraceID", "SpellID" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "SubracesSpell",
                columns: new[] { "SubraceID", "SpellID" },
                values: new object[] { 4, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Source",
                table: "Classes",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_ClasseSpells_SpellID",
                table: "ClasseSpells",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Source",
                table: "Spells",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_Subclasses_Classe",
                table: "Subclasses",
                column: "Classe");

            migrationBuilder.CreateIndex(
                name: "IX_Subclasses_Source",
                table: "Subclasses",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_SubclassSpell_SpellID",
                table: "SubclassSpell",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_Subraces_BookID",
                table: "Subraces",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_SubracesSpell_SpellID",
                table: "SubracesSpell",
                column: "SpellID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClasseSpells");

            migrationBuilder.DropTable(
                name: "SubclassSpell");

            migrationBuilder.DropTable(
                name: "SubracesSpell");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subclasses");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Subraces");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
