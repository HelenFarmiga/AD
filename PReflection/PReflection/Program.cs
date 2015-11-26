using System;

namespace PReflection
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Object i=33;
			Type typeI = i.GetType();
			showType (typeI);

			string s="Hola";
			Type typeS = s.GetType ();
			showType (typeS);

			Type typeX = typeof(string);
			showType (typeX);			

			Type typeFoo = typeof(Foo);
			showType (typeFoo);
		}
		private static void showType(Type type){
			Console.WriteLine ("type.Name={0} type.FullName={1} type.BaseType.UriHostNameType{2}", 
			                   type.Name, type.FullName, type.BaseType.Name);
	}
		public class Foo {
			private string name;
			public string Name {
				get {
					return name;
				}
				set {
					name = value;
				}
		}
		}
	}
}

