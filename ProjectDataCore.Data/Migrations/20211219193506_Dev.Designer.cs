﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectDataCore.Data.Database;

#nullable disable

namespace ProjectDataCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211219193506_Dev")]
    partial class Dev
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectDataCore.Data.Account.DataCoreRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ProjectDataCore.Data.Account.DataCoreUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessCode")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<decimal?>("DiscordId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("DisplayId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("SteamLink")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentLayoutId")
                        .HasColumnType("uuid");

                    b.Property<string>("QualifiedTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("ParentLayoutId");

                    b.ToTable("PageComponentSettingsBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PageComponentSettingsBase");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.CustomPageSettings", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LayoutId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("Route")
                        .IsUnique();

                    b.ToTable("CustomPageSettings");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterDisplaySettings", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("HostRosterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("HostRosterId");

                    b.ToTable("RosterDisplaySettings");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterObject", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("RosterObject");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RosterObject");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterOrder", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("ParentObjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SlotToOrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreeToOrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Key");

                    b.HasIndex("ParentObjectId");

                    b.HasIndex("SlotToOrderId")
                        .IsUnique();

                    b.HasIndex("TreeToOrderId");

                    b.ToTable("RosterOrders");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Util.DataCoreUserProperty", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Alias")
                        .HasColumnType("integer");

                    b.Property<string>("FormatString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("RosterComponentDefaultDisplayId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RosterComponentUserListingDisplayId")
                        .HasColumnType("uuid");

                    b.HasKey("Key");

                    b.HasIndex("RosterComponentDefaultDisplayId");

                    b.HasIndex("RosterComponentUserListingDisplayId");

                    b.ToTable("DataCoreUserProperty");
                });

            modelBuilder.Entity("RosterComponentSettingsRosterDisplaySettings", b =>
                {
                    b.Property<Guid>("AvalibleRostersKey")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DisplayComponentsKey")
                        .HasColumnType("uuid");

                    b.HasKey("AvalibleRostersKey", "DisplayComponentsKey");

                    b.HasIndex("DisplayComponentsKey");

                    b.ToTable("RosterComponentSettingsRosterDisplaySettings");
                });

            modelBuilder.Entity("RosterTreeRosterTree", b =>
                {
                    b.Property<Guid>("ChildRostersKey")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParentRostersKey")
                        .HasColumnType("uuid");

                    b.HasKey("ChildRostersKey", "ParentRostersKey");

                    b.HasIndex("ParentRostersKey");

                    b.ToTable("RosterTreeRosterTree");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.LayoutComponentSettings", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase");

                    b.Property<int>("MaxChildComponents")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentPageId")
                        .HasColumnType("uuid");

                    b.HasIndex("ParentPageId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("LayoutComponentSettings");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.ParameterComponentSettingsBase", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase");

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<string>("PropertyToEdit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("StaticProperty")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("UserScopeId")
                        .HasColumnType("uuid");

                    b.HasIndex("UserScopeId");

                    b.HasDiscriminator().HasValue("ParameterComponentSettingsBase");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.RosterComponentSettings", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase");

                    b.Property<bool>("AllowUserLisiting")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("DefaultRoster")
                        .HasColumnType("uuid");

                    b.Property<int>("Depth")
                        .HasColumnType("integer");

                    b.Property<int>("LevelFromTop")
                        .HasColumnType("integer");

                    b.Property<bool>("Scoped")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("RosterComponentSettings");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterSlot", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Roster.RosterObject");

                    b.Property<int?>("OccupiedById")
                        .HasColumnType("integer");

                    b.Property<Guid>("ParentRosterId")
                        .HasColumnType("uuid");

                    b.HasIndex("OccupiedById");

                    b.HasIndex("ParentRosterId");

                    b.HasDiscriminator().HasValue("RosterSlot");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterTree", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Roster.RosterObject");

                    b.HasDiscriminator().HasValue("RosterTree");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.DisplayComponentSettings", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Page.Components.ParameterComponentSettingsBase");

                    b.Property<string>("FormatString")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("DisplayComponentSettings");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.EditableComponentSettings", b =>
                {
                    b.HasBaseType("ProjectDataCore.Data.Structures.Page.Components.ParameterComponentSettingsBase");

                    b.Property<string>("Placeholder")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("EditableComponentSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectDataCore.Data.Account.DataCoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Page.Components.LayoutComponentSettings", "ParentLayout")
                        .WithMany("ChildComponents")
                        .HasForeignKey("ParentLayoutId");

                    b.Navigation("ParentLayout");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterDisplaySettings", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", "HostRoster")
                        .WithMany("DisplaySettings")
                        .HasForeignKey("HostRosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HostRoster");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterOrder", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", "ParentObject")
                        .WithMany("OrderChildren")
                        .HasForeignKey("ParentObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterSlot", "SlotToOrder")
                        .WithOne("Order")
                        .HasForeignKey("ProjectDataCore.Data.Structures.Roster.RosterOrder", "SlotToOrderId");

                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", "TreeToOrder")
                        .WithMany("Order")
                        .HasForeignKey("TreeToOrderId");

                    b.Navigation("ParentObject");

                    b.Navigation("SlotToOrder");

                    b.Navigation("TreeToOrder");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Util.DataCoreUserProperty", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Page.Components.RosterComponentSettings", null)
                        .WithMany("DefaultDisplayedProperties")
                        .HasForeignKey("RosterComponentDefaultDisplayId");

                    b.HasOne("ProjectDataCore.Data.Structures.Page.Components.RosterComponentSettings", null)
                        .WithMany("UserListDisplayedProperties")
                        .HasForeignKey("RosterComponentUserListingDisplayId")
                        .HasConstraintName("FK_DataCoreUserProperty_PageComponentSettingsBase_RosterCompo~1");
                });

            modelBuilder.Entity("RosterComponentSettingsRosterDisplaySettings", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterDisplaySettings", null)
                        .WithMany()
                        .HasForeignKey("AvalibleRostersKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectDataCore.Data.Structures.Page.Components.RosterComponentSettings", null)
                        .WithMany()
                        .HasForeignKey("DisplayComponentsKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterTreeRosterTree", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", null)
                        .WithMany()
                        .HasForeignKey("ChildRostersKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", null)
                        .WithMany()
                        .HasForeignKey("ParentRostersKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.LayoutComponentSettings", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Page.CustomPageSettings", "ParentPage")
                        .WithOne("Layout")
                        .HasForeignKey("ProjectDataCore.Data.Structures.Page.Components.LayoutComponentSettings", "ParentPageId");

                    b.Navigation("ParentPage");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.ParameterComponentSettingsBase", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase", "UserScope")
                        .WithMany("AttachedScopes")
                        .HasForeignKey("UserScopeId");

                    b.Navigation("UserScope");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterSlot", b =>
                {
                    b.HasOne("ProjectDataCore.Data.Account.DataCoreUser", "OccupiedBy")
                        .WithMany("RosterSlots")
                        .HasForeignKey("OccupiedById");

                    b.HasOne("ProjectDataCore.Data.Structures.Roster.RosterTree", "ParentRoster")
                        .WithMany("RosterPositions")
                        .HasForeignKey("ParentRosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OccupiedBy");

                    b.Navigation("ParentRoster");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Account.DataCoreUser", b =>
                {
                    b.Navigation("RosterSlots");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.PageComponentSettingsBase", b =>
                {
                    b.Navigation("AttachedScopes");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.CustomPageSettings", b =>
                {
                    b.Navigation("Layout");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.LayoutComponentSettings", b =>
                {
                    b.Navigation("ChildComponents");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Page.Components.RosterComponentSettings", b =>
                {
                    b.Navigation("DefaultDisplayedProperties");

                    b.Navigation("UserListDisplayedProperties");
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterSlot", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectDataCore.Data.Structures.Roster.RosterTree", b =>
                {
                    b.Navigation("DisplaySettings");

                    b.Navigation("Order");

                    b.Navigation("OrderChildren");

                    b.Navigation("RosterPositions");
                });
#pragma warning restore 612, 618
        }
    }
}