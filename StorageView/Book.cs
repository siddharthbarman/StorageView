using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageView
{
	class Book : TableEntity
	{
		public Book(string isbn, string author, string title, int firstPublicationYear, string language) {
			Author = author;
			Language = language;
			PartitionKey = language;
			RowKey = isbn;
			Title = title;
			FirstPublicationYear = firstPublicationYear;
		}

		public string Author {
			get;
			set;
		}

		public string Title {
			get;
			set;
		} 

		public int FirstPublicationYear {
			get;
			set;
		}

		public string Language {
			get;
			set;
		}
	}
}
