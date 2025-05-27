using SpeedyParts.DTO;
namespace SpeedyParts.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
