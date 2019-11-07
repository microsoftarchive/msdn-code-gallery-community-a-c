//Importa as DLLs básicas para um classe.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importamos a DLL DataAnnotations
//Faz anotações em nossas propriedades.
using System.ComponentModel.DataAnnotations;

//Representa a camada em que estamos trabalhando.
namespace NetCoders.Agenda.Model
{
    //Quando a classe é criado pelo Programador. Por default seu modificador de acesso é INTERNAL
    //Devemos colocar o modificador PUBLIC para que possamos enxergar em nossas camadas.
    public sealed class AgendaMOD
    {
        public int Codigo { get; set; }

        //String e string, as diferencças, tipo primitivo e tipo por referencia.
        //string sobe do C#, enquanto String sobe da Plataforma .NET.
        //Porque? O tipo de dados da Plataforma .NET ajuda quando desenvolvemos sistemas hibridos.
        //Exemplo Mesclagem VB.NET com C# .NET.
        [Display(Name = "Título: ")]
        [Required(ErrorMessage = "Ops!, Informe o título.")]
        [DataType(DataType.Text, ErrorMessage = "Ops!, Informe somente texto.")]
        public String Titulo { get; set; }

        [Display(Name = "Descrição Simples: ")]
        [Required(ErrorMessage = "Ops!, Informe a descrição simples.")]
        [DataType(DataType.Text, ErrorMessage = "Ops!, Informe somente texto.")]
        public string DescricaoSimples { get; set; }

        //Dentro de classes Modelos devemos ter nossas PROPRIEDADES que representam nossos ATRIBUTOS.
        //Toda propriedade para ser visualizada e configurada, deve ter os metodos getters e setters.
        //{ get; set;  }

        [Display(Name = "Descrição Completa: ")]
        [Required(ErrorMessage = "Ops!, Informe a descrição completa.")]
        [DataType(DataType.Text, ErrorMessage = "Ops!, Informe somente texto.")]
        public string DescricaoCompleta { get; set; }

        [Display(Name = "Data: ")]
        [Required(ErrorMessage = "Ops!, Informe a data.")]
        [DataType(DataType.Date, ErrorMessage = "Ops!, Informe somente data válida.")]
        public DateTime Data { get; set; }

        public DateTime Gravado { get; set; }
    }
}
