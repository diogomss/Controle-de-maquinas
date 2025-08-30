using ControleMaquinas.Enums;
using ControleMaquinas.models;
using ControleMaquinas.Models;
using ControleMaquinas.Service.MaquinaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : ControllerBase    //Pega lógica do maquinaService.cs e utiliza nas rotas
    {
        private readonly IMaquinaInterface _maquinaInterface;
        public MaquinaController(IMaquinaInterface maquinaInterface)
        {
            _maquinaInterface = maquinaInterface; //Usando interface para acessar a lógica do programa
        }

        [HttpGet("Lista de máquinas")]
        public async Task<ActionResult<ServiceResponse<List<MaquinaModel>>>> GetMaquinas()
        {
            return Ok(await _maquinaInterface.GetMaquinas()); 
        }

        [HttpGet("Maquinas por status")]
        public async Task<ActionResult<ServiceResponse<MaquinaModel>>> GetMaquinaByStatus(StatusEnum status)
        {
            ServiceResponse<MaquinaModel> serviceResponse = await _maquinaInterface.GetMaquinaByStatus(status);
            return Ok(serviceResponse);
        }

        [HttpPost("Criar nova máquina")]
        public async Task<ActionResult<ServiceResponse<List<MaquinaModel>>>> CreateMaquina(MaquinaModel NovaMaquina)
        {
            return Ok(await _maquinaInterface.CreateMaquina(NovaMaquina));
        }

        [HttpPut("Atualização de máquina")]
        public async Task<ActionResult<ServiceResponse<List<MaquinaModel>>>> UpdateMaquina(MaquinaModel MaquinaAtualizada)
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = await _maquinaInterface.UpdateMaquina(MaquinaAtualizada);
            return Ok(serviceResponse);
        }

        [HttpDelete("Deletar máquina por Id")]
        public async Task<ActionResult<ServiceResponse<List<MaquinaModel>>>> DeleteMaquina(int Id)
        {
            ServiceResponse<List<MaquinaModel>> serviceResponse = await _maquinaInterface.DeleteMaquina(Id);

            return Ok(serviceResponse);
        }
    }
}
