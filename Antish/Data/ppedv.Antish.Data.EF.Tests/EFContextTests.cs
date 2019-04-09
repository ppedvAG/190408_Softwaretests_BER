﻿using NUnit.Framework;
using ppedv.Antish.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Antish.Data.EF.Tests
{
    [TestFixture]
    public class EFContextTests
    {
        const string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=Antish_TestDB;Trusted_Connection=true;AttachDbFileName=C:\temp\antish.mdf";
        [Test]
        [Category("Integrationstest: Funktioniert EF?")]
        public void EFContext_can_create_Context()
        {
            var context = new EFContext(connectionString);
        }

        [Test]
        [Category("Integrationstest: Funktioniert EF?")]
        public void EFContext_can_create_DB()
        {
            using (var context = new EFContext(connectionString))
            {
                // Grundvorraussetzung: es darf keine DB da sein !
                if (context.Database.Exists())
                    context.Database.Delete();

                // Startbedingung: keine DB
                Assert.False(context.Database.Exists());

                context.Database.Create();
                Assert.True(context.Database.Exists()); // Jetzt muss die DB da sein
            }
        }

        // CRUD-Tests: Create,Read,Update,Delete

        [Test]
        [Category("Integrationstest: Funktioniert EF?")]
        public void EFContext_can_CRUD_Person()
        {
            var p1 = new Person
            {
                FirstName = "Tom",
                LastName = "Ate",
                Age = 10,
                Balance = 100m
            };
            string newLastName = "Atinger";

            // Create
            using (var context = new EFContext(connectionString))
            {
                context.Person.Add(p1);
                context.SaveChanges(); // Speichern !
            }

            // Grund für einen neuen Context: Person soll aus der DB und nicht aus dem Cache ausgelesen werden !!!
            using (var context = new EFContext(connectionString))
            {
                // Check für Create + Read
                var loadedPerson = context.Person.Find(p1.ID); // ID wird mit dem .Add() oben automatisch erstellt
                Assert.NotNull(loadedPerson);
                Assert.AreEqual(p1.FirstName,loadedPerson.FirstName);
                // Variante "einfach"... Richtiger Vergleich: ObjectGraph

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check für Update
                var loadedPerson = context.Person.Find(p1.ID); // ID wird mit dem .Add() oben automatisch erstellt
                Assert.NotNull(loadedPerson);
                Assert.AreEqual(newLastName, loadedPerson.LastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check für Delete
                var loadedPerson = context.Person.Find(p1.ID); // ID wird mit dem .Add() oben automatisch erstellt
                Assert.IsNull(loadedPerson);
            }
        }

    }
}
