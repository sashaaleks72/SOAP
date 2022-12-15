using System.Collections.Generic;
using System.ServiceModel;
using WcfTest.Models;

namespace WcfTest.Interfaces
{
    [ServiceContract]
    public interface ITeapotService
    {
        [OperationContract]
        int AddTeapot(Teapot newTeapot);

        [OperationContract]
        int DeleteTeapotById(int id);

        [OperationContract]
        List<Teapot> GetTeapots();

        [OperationContract]
        Teapot GetTeapotById(int id);

        [OperationContract]
        int EditTeapot(Teapot editedTeapot);

    }
}
