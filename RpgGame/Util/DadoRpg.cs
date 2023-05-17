namespace RpgGame.Util
{
    public class DadoRpg
    {
        public int QtdDados { get; private set; }
        public int FacesDado { get; private set; }
        public int Resultado { get; private set; }

        public DadoRpg(int qtdDados, int facesDado)
        {
            QtdDados = qtdDados;
            FacesDado = facesDado;
        }


        public int Jogar()
        {
            Resultado = 0;
            int resultado = 0;

            for (int i = 0; i < QtdDados; i++)
            {
                Random random = new Random();
                int resultadoDado = random.Next(1, FacesDado);
                resultado = resultado + resultadoDado;
            }

            Resultado = resultado;
            return resultado;
        }
    }
}
