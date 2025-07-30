namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de uma venda no sistema.
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Obtém o número da venda.
        /// </summary>
        /// <returns>O SaleNumber da venda.</returns>
        public long SaleNumber { get; }
    }
}
