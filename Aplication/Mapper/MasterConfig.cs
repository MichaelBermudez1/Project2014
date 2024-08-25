using Domain.DTOS;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MasterConfig
    {

        public static void RegisterMappings()
        {
            //Vehiculos
            TypeAdapterConfig<GestorVehiculos, DTOVehiculos>.NewConfig()
                .Map(dest => dest.IdVehiculo, src => src.VehiId)
                .Map(dest => dest.IdProveedor, src => src.ProviId)
                .Map(dest => dest.VehiculoMarca, src => src.VehivMarca)
                .Map(dest => dest.VehiculoModelo, src => src.VehivModelo)
                .Map(dest => dest.VehiculoAnio, src => src.VehinAno)
                .Map(dest => dest.VehiculoPlaca, src => src.VehicPlaca)
                .Map(dest => dest.DTODocVehiculos, src => src.GestorDocVehiculos); // Aquí se mapea la colección

            TypeAdapterConfig<DTOVehiculos, GestorVehiculos>.NewConfig()
               .Map(dest => dest.VehiId, src => src.IdVehiculo)
               .Map(dest => dest.ProviId, src => src.IdProveedor)
               .Map(dest => dest.VehivMarca, src => src.VehiculoMarca)
               .Map(dest => dest.VehivModelo, src => src.VehiculoModelo)
               .Map(dest => dest.VehinAno, src => src.VehiculoAnio)
               .Map(dest => dest.VehicPlaca, src => src.VehiculoPlaca)
               .Map(dest => dest.GestorDocVehiculos, src => src.DTODocVehiculos); // Aquí se mapea la colección

            TypeAdapterConfig<GestorDocVehiculos, DTODocVehiculos>.NewConfig()
               .Map(dest => dest.DocIdVehiculo, src => src.DocvehiId)
               .Map(dest => dest.IdVehiculo, src => src.VehiId)
               .Map(dest => dest.IdProveedor, src => src.ProviId)
               .Map(dest => dest.DescrpicionVehiculo, src => src.DocvehivDescripcion)
               .Map(dest => dest.FechaRegistroVehiculo, src => src.DocvehidFechaReg)
               .Map(dest => dest.DocumentoVehiculoRuta, src => src.DocvehivRuta)
               .Map(dest => dest.IdDocumentoStorage, src => src.DocIdDocumentoStorage);


            TypeAdapterConfig<DTODocVehiculos, GestorDocVehiculos>.NewConfig()
               .Map(dest => dest.DocvehiId, src => src.DocIdVehiculo)
               .Map(dest => dest.VehiId, src => src.IdVehiculo)
               .Map(dest => dest.ProviId, src => src.IdProveedor)
               .Map(dest => dest.DocvehivDescripcion, src => src.DescrpicionVehiculo)
               .Map(dest => dest.DocvehidFechaReg, src => src.FechaRegistroVehiculo)
               .Map(dest => dest.DocvehivRuta, src => src.DocumentoVehiculoRuta)
               .Map(dest => dest.DocIdDocumentoStorage, src => src.IdDocumentoStorage);

            //Colaboradores
            TypeAdapterConfig<GestorColaboradores, DTOGestorColaboradores>.NewConfig()
               .Map(dest => dest.IdColaborador, src => src.ColaiId)
               .Map(dest => dest.IdProveedor, src => src.ProviId)
               .Map(dest => dest.ColaboradoresNombres, src => src.ColavNombres)
               .Map(dest => dest.ColaboradoresApellidosPat, src => src.ColavApellidoPat)
               .Map(dest => dest.ColaboradoresApellidosMat, src => src.ColavApellidoMat)
               .Map(dest => dest.ColaboradoresDireccion, src => src.ColavDireccion)
               .Map(dest => dest.ColaboradoresTipoDoc, src => src.ColavTipoDoc)
               .Map(dest => dest.ColaboresNumDoc, src => src.ColaiNumeroDoc)
               .Map(dest => dest.ColaboradoresNacionalidad, src => src.ColavNacionalidad)
               .Map(dest => dest.ColaboradoresPuestoTrabajo, src => src.ColavPuestoTrabajo)
               .Map(dest => dest.ColaboradoresSexo, src => src.ColavSexo)
               .Map(dest => dest.DTOGestorDocColaboradores, src => src.GestorDocColaboradores);

            TypeAdapterConfig<DTOGestorColaboradores, GestorColaboradores>.NewConfig()
               .Map(dest => dest.ColaiId, src => src.IdColaborador)
               .Map(dest => dest.ProviId, src => src.IdProveedor)
               .Map(dest => dest.ColavNombres, src => src.ColaboradoresNombres)
               .Map(dest => dest.ColavApellidoPat, src => src.ColaboradoresApellidosPat)
               .Map(dest => dest.ColavApellidoMat, src => src.ColaboradoresApellidosMat)
               .Map(dest => dest.ColavDireccion, src => src.ColaboradoresDireccion)
               .Map(dest => dest.ColavTipoDoc, src => src.ColaboradoresTipoDoc)
               .Map(dest => dest.ColaiNumeroDoc, src => src.ColaboresNumDoc)
               .Map(dest => dest.ColavNacionalidad, src => src.ColaboradoresNacionalidad)
               .Map(dest => dest.ColavPuestoTrabajo, src => src.ColaboradoresPuestoTrabajo)
               .Map(dest => dest.ColavSexo, src => src.ColaboradoresSexo)
               .Map(dest => dest.GestorDocColaboradores, src => src.DTOGestorDocColaboradores);

            TypeAdapterConfig<GestorDocColaboradores, DTOGestorDocColaboradores>.NewConfig()
               .Map(dest => dest.IdDocColaboradores, src => src.DoccolaiId)
               .Map(dest => dest.IdColaboradores, src => src.ColaiId)
               .Map(dest => dest.IdProveedor, src => src.ProviId)
               .Map(dest => dest.DocDecripcionDocumentosColaboradores, src => src.DoccolavDescripcion)
               .Map(dest => dest.DocFechaRegistroDocColabores, src => src.DoccoladFechaReg)
               .Map(dest => dest.DocumentoColaboresRuta, src => src.DoccolavRuta)
               .Map(dest => dest.IdDocumentoStorageColaborador, src => src.DocIdDocumentoStorage);
              
            TypeAdapterConfig<DTOGestorDocColaboradores, GestorDocColaboradores>.NewConfig()
              .Map(dest => dest.DoccolaiId, src => src.IdDocColaboradores)
              .Map(dest => dest.ColaiId, src => src.IdColaboradores)
              .Map(dest => dest.ProviId, src => src.IdProveedor)
              .Map(dest => dest.DoccolavDescripcion, src => src.DocDecripcionDocumentosColaboradores)
              .Map(dest => dest.DoccoladFechaReg, src => src.DocFechaRegistroDocColabores)
              .Map(dest => dest.DoccolavRuta, src => src.DocumentoColaboresRuta)
              .Map(dest => dest.DocIdDocumentoStorage, src => src.IdDocumentoStorageColaborador);
              

        }
    }
}
