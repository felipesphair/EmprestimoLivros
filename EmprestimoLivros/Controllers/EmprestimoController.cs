using ClosedXML.Excel;
using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db) 
        { 
            _db = db; 
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;

            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimo)
        {
           if(ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
           return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null) 
            {
                return NotFound();
            }
            return View(emprestimo);

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo) 
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";


            return View(emprestimo);
        }


        [HttpGet]
        public IActionResult Deletar(int? id)
        {
            if(id == null || id == 0)
                return NotFound();

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id==id);

            if(emprestimo == null)
                return NotFound();

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Deletar(EmprestimosModel emprestimo)
        {
            if(emprestimo == null)
                return NotFound();

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizado com sucesso!";

            return RedirectToAction("Index");
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add(dados, "Dados Empréstimos");

                // Definindo a largura das colunas
                for (int i = 0; i < dados.Columns.Count; i++)
                {
                    worksheet.Column(i + 1).Width = 20;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    workBook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Emprestimo.xlsx");
                }
            }
        }


        private DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados empréstimos";
            dataTable.Columns.Add("Recebedor",  typeof(string));
            dataTable.Columns.Add("Fornecedor",  typeof(string));
            dataTable.Columns.Add("Livro",  typeof(string));
            dataTable.Columns.Add("Data última atualização",  typeof(DateTime));

            var dados = _db.Emprestimos.ToList();

            if(dados.Count > 0)
            {
                dados.ForEach(x => dataTable.Rows.Add(
                    x.Recebedor, x.Fornecedor, x.LivroEmprestado, x.DataUltimaAtualizacao
                    ));
            }



            return dataTable;
        }
    }
}
