using System;
using BookStore.Models.Models;

namespace BookStore.DL.InMemoryDb
{
	public static class InMemoryDb
	{
		public static List<Author> Authors = new List<Author>()
		{
			new Author()
			{
				Id = 1,
				Name = "Denkata"
			},

			new Author()
			{
				Id = 2,
				Name = "Peshkata"
			}
		};

	}
}

