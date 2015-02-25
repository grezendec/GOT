using System;

namespace GUT.Infra
{
    public class GritterMessage
    {
        #region Enum

        public enum TipoGritter
        {
            Info = 0,
            Alert = 1,
            Error = 2,
            Success = 3
        }

        #endregion

        #region Variaveis

        private int? _tempo;

        #endregion

        #region Construtores

        public GritterMessage(string titulo, string mensagem, TipoGritter tipo)
        {
            Titulo = titulo;
            Mensagem = mensagem;
            Tipo = tipo;
        }

        public GritterMessage(string mensagem, TipoGritter tipo)
        {
            Mensagem = mensagem;
            Tipo = tipo;
        }

        public GritterMessage(string titulo, string mensagem, TipoGritter tipo, int tempo, bool fixar)
        {
            Titulo = titulo;
            Mensagem = mensagem;
            Tipo = tipo;
            Tempo = tempo;
            Fixar = fixar;
        }

        public GritterMessage(string mensagem, TipoGritter tipo, int tempo, bool fixar)
        {
            Mensagem = mensagem;
            Tipo = tipo;
            Tempo = tempo;
            Fixar = fixar;
        }

        #endregion
        
        #region Propriedades

        public String Titulo { get; set; }

        public String Mensagem { get; set; }

        public int Tempo
        {
            get
            {
                return _tempo.HasValue ? _tempo.Value : Math.Max((Int32)(Math.Ceiling(0.1 * Mensagem.Length) * 2), 5);
            }
            set
            {
                _tempo = value;
            }
        }

        public TipoGritter Tipo { get; set; }

        public bool Fixar { get; set; }

        #endregion
    }
}
