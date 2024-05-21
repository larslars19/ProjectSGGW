using System;
namespace Projekt
{
	public interface ISeriazible
	{
		public string ToString();
		public static abstract object FromString(string data);
	}
}

