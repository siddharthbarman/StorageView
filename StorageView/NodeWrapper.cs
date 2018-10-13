using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageView
{
	class NodeWrapper
	{
		public NodeWrapper(bool isLoaded, object context) {
			IsLoaded = isLoaded;
			Context = context;
		}

		public bool IsLoaded { get; set; }
		public object Context { get; set; }
	}
}
