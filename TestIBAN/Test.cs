using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIBAN;
using NUnit.Framework;

namespace TestIBAN
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void CuentaCorrienteVacia()
        {
            try
            {
                Iban.calcularIban("");
                Assert.Fail("Cuenta Corriente Vacia, no se puede calcular el IBAN");
            }
            catch
            {
            }
        }

        [Test]
        public void ValidarIbanEsValido()
        {
            string iban = Iban.calcularIban("1234567891");
            Assert.AreEqual(true, Iban.EsIBANvalido(iban));
        }

        [Test]
        public void ValidarIbanNoEsValido()
        {
            string iban = Iban.calcularIban("0987654321");
            Assert.AreNotEqual(true, Iban.EsIBANvalido(iban));
        }

        [Test]
        public void CalculoIBANCorrecto()
        { 
            string iban= Iban.calcularIban("00492352082414205416");
            Assert.AreEqual("14281000492352082414205416", iban);
        }

        [Test]
        public void CalculoIBANNoEsCorrecto()
        {
            string iban = Iban.calcularIban("00492352082414205416");
            Assert.AreNotEqual("14280500492352082414205416", iban);
        }

        
    }
}
