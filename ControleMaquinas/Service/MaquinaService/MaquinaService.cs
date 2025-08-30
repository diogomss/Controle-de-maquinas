using ControleMaquinas.DataContext;
using ControleMaquinas.Enums;
using ControleMaquinas.models;
using ControleMaquinas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinas.Service.MaquinaService
{                                                             //Lógica do programa
    public class MaquinaService : IMaquinaInterface
    {
        private readonly ApplicationDbContext _context; //Acesso ao banco de dados pelo Service
        public MaquinaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MaquinaModel>>> CreateMaquina(MaquinaModel NovaMaquina)
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = new ServiceResponse<List<MaquinaModel>>();
           
            try
            {
                if (NovaMaquina == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(NovaMaquina);//adiciona a nova máquina ao banco de dados
                await _context.SaveChangesAsync(); //salva as mudanças no banco de dados

                serviceResponse.Dados = _context.Maquinas.ToList(); //retorna a lista atualizada de máquinas
                serviceResponse.Mensagem = "Máquina criada com sucesso !";
            }
            catch (Exception ex)
            {


                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MaquinaModel>>> DeleteMaquina(int Id)
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = new ServiceResponse<List<MaquinaModel>>();

            try
            {
                MaquinaModel maquina = _context.Maquinas.FirstOrDefault(m => m.Id == Id);

                if (maquina == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Máquina não encontrada";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Maquinas.Remove(maquina);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Maquinas.ToList();
                serviceResponse.Mensagem = "Máquina deletada com sucesso !";
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<MaquinaModel>> GetMaquinaByStatus(StatusEnum Status)
        {
            ServiceResponse<MaquinaModel> serviceResponse = new ServiceResponse<MaquinaModel>();
            try
            {
                MaquinaModel maquina = _context.Maquinas.FirstOrDefault(m => m.Status == Status);

                if (maquina == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Máquina não encontrada";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = maquina;
                serviceResponse.Mensagem = "Máquina encontrada com sucesso !";
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MaquinaModel>>> GetMaquinas()
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = new ServiceResponse<List<MaquinaModel>>();

            try
            {
                serviceResponse.Dados = _context.Maquinas.ToList();
                serviceResponse.Mensagem = "Lista de máquinas retornada com sucesso !";

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhuma máquina cadastrada";
                }
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MaquinaModel>>> UpdateMaquina(MaquinaModel MaquinaAtualizada)
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = new ServiceResponse<List<MaquinaModel>>();

            try
            {
                MaquinaModel maquina = _context.Maquinas.AsNoTracking().FirstOrDefault(m => m.Id == MaquinaAtualizada.Id);

                if (maquina.Id == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Máquina não encontrada";
                    serviceResponse.Sucesso = false;
                }

                _context.Maquinas.Update(MaquinaAtualizada);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Maquinas.ToList();
                serviceResponse.Mensagem = "Máquina atualizada com sucesso !";
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
