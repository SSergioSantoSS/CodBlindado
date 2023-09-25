using NewProj;

namespace Test_NewProj
{
    public class UnitTest1
    {
        public Calculadora ConstruirCal ()
        {
            string data = "01/01/2020";
            Calculadora calc = new Calculadora ("01/01/2020");

            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirCal();

            int resultadoCalculadora = calc.somar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(6, 2, 4)]
        public void TesteSubtrair(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirCal();

            int resultadoCalculadora = calc.subtrair(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirCal();

            int resultadoCalculadora = calc.multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirCal();

            int resultadoCalculadora = calc.dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        
        public void TesteDivisaoPorZero()
        {
            Calculadora calc = ConstruirCal();

            Assert.Throws<DivideByZeroException>(
                ()=> calc.dividir(3,0)
            );
        }

        [Fact]
        
        public void TesteHistorico()
        {
            Calculadora calc = ConstruirCal();

            calc.somar(1, 2);
            calc.subtrair(2, 8);
            calc.multiplicar(3, 7);
            calc.dividir(4,1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}