﻿using budjit.core.data.Contracts;
using budjit.core.data.SQLite;
using budjit.core.models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace budjit.core.data.test.SQLite
{
    [TestClass]
    public class TagRepositoryTest
    {
        private DbContextOptions<BudjitContext> contextOptions;

        public TagRepositoryTest()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            DbContextOptions<BudjitContext> options;
            var builder = new DbContextOptionsBuilder<BudjitContext>();
            builder.UseSqlite(connection);
            options = builder.Options;

            contextOptions = options;
        }

        private BudjitContext GetContext(DbContextOptions<BudjitContext> options)
        {
            var context = new BudjitContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }


        [TestMethod]
        public void ShouldGetAllTags()
        {
            using (var context = GetContext(contextOptions))
            {
                var tags = Enumerable.Range(1, 10)
                .Select(i => new Tag() { ID = i, Name = $"Tag {i}" });

                context.Tags.AddRange(tags);
                context.SaveChanges();
            }

            List<Tag> foundTags;

            using (var context = GetContext(contextOptions))
            {
                ITagRepository repository = new TagRepository(context);
                foundTags = repository.GetAll().ToList();
            }
            Assert.AreEqual(10, foundTags.Count);
        }

        [TestMethod]
        public void ShouldGetTagById()
        {
            using (var context = GetContext(contextOptions))
            {
                var tags = Enumerable.Range(1, 10)
                .Select(i => new Tag() { ID = i, Name = $"Tag {i}" });

                context.Tags.AddRange(tags);
                context.SaveChanges();
            }

            Tag foundTag;
            using (var context = GetContext(contextOptions))
            {
                ITagRepository repository = new TagRepository(context);
                foundTag = repository.GetById(1);
            }

            Assert.AreEqual(1, foundTag.ID);
        }
    }
}
