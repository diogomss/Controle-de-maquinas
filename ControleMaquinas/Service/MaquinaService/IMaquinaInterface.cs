using ControleMaquinas.Enums;
using ControleMaquinas.models;
using ControleMaquinas.Models;

namespace ControleMaquinas.Service.MaquinaService
{
    public interface IMaquinaInterface    //Interface com os métodos que serão implementados na lógica do programa
    {                
        Task<ServiceResponse<List<MaquinaModel>>> GetMaquinas(); //retorna lista de máquinas
        Task<ServiceResponse<List<MaquinaModel>>> CreateMaquina(MaquinaModel NovaMaquina); //Cria máquina
        Task<ServiceResponse<MaquinaModel>> GetMaquinaByStatus(StatusEnum Status); //retorna máquina por Status
        Task<ServiceResponse<List<MaquinaModel>>> UpdateMaquina(MaquinaModel MaquinaAtualizada); //atualiza máquina
        Task<ServiceResponse<List<MaquinaModel>>> DeleteMaquina(int Id); //deleta máquina
    }
}
