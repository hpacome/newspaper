using newspaper.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace newspaper.repository.IntegrationTest
{
    public static class DbData
    {
        public static Guid Author101Id = new Guid("06ad0310-d2d9-4c3f-bc2b-24737a231165");
        public static string Author101Name = "Author101Name";
        public static string Author101Email = "Author101@email.test";
        public static Author Author101 = new Author(Author101Id, Author101Name, Author101Email);

        public static Guid Author102Id = new Guid("b92706be-85d5-4467-8051-6e601555d0c8");
        public static string Author102Name = "Author102Name";
        public static string Author102Email = "Author102@email.test";
        public static Author Author102 = new Author(Author102Id, Author102Name, Author102Email);
        
        public static Guid Author103Id = new Guid("a6dbeef0-8eec-4633-85ee-cb21eab94dab");
        public static string Author103Name = "Author103Name";
        public static string Author103Email = "Author103@email.test";
        public static Author Author103 = new Author(Author103Id, Author103Name, Author103Email);

        public static Guid Author104Id = new Guid("a6dbeef0-8eec-4633-85ee-cb21eab94dab");
        public static string Author104Name = "Author103Name";
        public static string Author104Email = "Author103@email.test";
        public static Author Author104 = new Author(Author103Id, Author103Name, Author103Email);

        public static IEnumerable<KeyValuePair<string, string>> GetCleansingSql()
        {
            IList<Guid> authorsIds = new List<Guid>
            {
                Author101Id,
                Author102Id,
                Author103Id,
            };
            return authorsIds.Select((id, i) => new KeyValuePair<string, string>(
                    $"cleansingScript:{i}",
                    $"DELETE FROM t_author WHERE id = '{id}'"
                ));
        }

        public static IEnumerable<KeyValuePair<string, string>> GetSeedSql()
        {
            IList<Author> authors = new List<Author>
            {
                Author102,
                Author103
            };
            return authors.Select((x, i) => new KeyValuePair<string, string>(
                    $"seedScript:{i}",
                    $"INSERT INTO t_author (id, name, email) VALUES ('{x.Id}', '{x.Name}', '{x.Email}')"
                ));
        }
    }
}
