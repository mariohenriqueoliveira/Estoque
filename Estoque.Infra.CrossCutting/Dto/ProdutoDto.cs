using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.CrossCutting.Dto
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string DescricaoProduto { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
