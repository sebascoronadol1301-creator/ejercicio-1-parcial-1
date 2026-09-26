using System;

namespace BancoApp.Models
{
    // 1. Clase Base
    public class CuentaBancaria
    {
        public decimal Saldo { get; set; }

        public CuentaBancaria(decimal saldo)
        {
            Saldo = saldo;
        }

        public virtual decimal CalcularInteresMensual()
        {
            return 0m;
        }
    }

    // 2. Clase Derivada: CuentaAhorros
    public class CuentaAhorros : CuentaBancaria
    {
        public decimal TasaPromocional { get; set; }

        public CuentaAhorros(decimal saldo, decimal tasaPromocional) : base(saldo)
        {
            TasaPromocional = tasaPromocional;
        }

        public override decimal CalcularInteresMensual()
        {
            return Saldo * TasaPromocional;
        }
    }

    // 3. Clase Derivada: CuentaInversion
    public class CuentaInversion : CuentaBancaria
    {
        public double FactorRiesgo { get; set; }

        public CuentaInversion(decimal saldo, double factorRiesgo) : base(saldo)
        {
            FactorRiesgo = factorRiesgo;
        }

        public override decimal CalcularInteresMensual()
        {
            return Saldo * (decimal)FactorRiesgo;
        }
    }
}

namespace BancoApp
{
    using BancoApp.Models;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CÁLCULO DE RENDIMIENTO FINANCIERO ===\n");

            // Creación de instancias
            CuentaAhorros cuentaAhorro = new CuentaAhorros(15000.00m, 0.05m); // 5% de tasa promocional
            CuentaInversion cuentaInversion = new CuentaInversion(50000.00m, 0.12); // 12% factor de riesgo

            // Ejecución polimórfica
            Console.WriteLine($"Saldo Cuenta de Ahorros: Q{cuentaAhorro.Saldo:F2}");
            Console.WriteLine($"Interés Mensual Generado: Q{cuentaAhorro.CalcularInteresMensual():F2}\n");

            Console.WriteLine($"Saldo Cuenta de Inversión: Q{cuentaInversion.Saldo:F2}");
            Console.WriteLine($"Interés Mensual Generado: Q{cuentaInversion.CalcularInteresMensual():F2}\n");
        }
    }
}