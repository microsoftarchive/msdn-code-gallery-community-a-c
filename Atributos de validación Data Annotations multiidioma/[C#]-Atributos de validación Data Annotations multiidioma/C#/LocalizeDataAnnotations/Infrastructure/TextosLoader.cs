
namespace LocalizeDataAnnotations.Infrastructure
{

	public static class TextosLoader
	{

			public static string Apellido
		{
			get { return TextosBBDD.Recuperar("Apellido"); }
		}
		public static string Ciudad
		{
			get { return TextosBBDD.Recuperar("Ciudad"); }
		}
		public static string CiudadErrorLongitud
		{
			get { return TextosBBDD.Recuperar("CiudadErrorLongitud"); }
		}
		public static string Email
		{
			get { return TextosBBDD.Recuperar("Email"); }
		}
		public static string Nombre
		{
			get { return TextosBBDD.Recuperar("Nombre"); }
		}
		public static string NombreObligatorio
		{
			get { return TextosBBDD.Recuperar("NombreObligatorio"); }
		}

	}

}