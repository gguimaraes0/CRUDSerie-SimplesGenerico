namespace CRUD_Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero = " + this.Genero + System.Environment.NewLine;
            retorno += "Título = " + this.Titulo + System.Environment.NewLine;
            retorno += "Descrição = " + this.Descricao + System.Environment.NewLine;
            retorno += "Ano de Início = " + this.Ano + System.Environment.NewLine;
            retorno += "Excluído = " + this.Excluido + System.Environment.NewLine;

            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool RetornaExcluido()
		{
			return this.Excluido;
		}
    }
}