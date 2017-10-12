using Sigmeh.Framework;
using Sigmeh.Model;
using Sigmeh.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Sigmeh.View
{
    public partial class EquipamentoTipoMan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdTipoEquipamento_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            using (UnitOfWork oUnitOfWork = new UnitOfWork())
            {
                grdTipoEquipamento.DataSource = oUnitOfWork.EquipamentoTipoREP.BuscarDadosGrid();
            }
        }
        protected void grdTipoEquipamento_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;
                EquipamentoTipo _equipamentoTipo = new EquipamentoTipo();                
                _equipamentoTipo.Descricao = (insertedItem["colDescricao"].Controls[0] as TextBox).Text;
                _equipamentoTipo.Observacao = (insertedItem["colObservacao"].Controls[0] as TextBox).Text;
                _equipamentoTipo.DataCriacao = DateTime.Now;
                _equipamentoTipo.UsuarioCriadorID = int.Parse(Session["ssnLoggedUserID"].ToString());
                _equipamentoTipo.DataModificacao = DateTime.Now;
                _equipamentoTipo.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    oUnitOfWork.EquipamentoTipoREP.Adicionar(_equipamentoTipo);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de Tipo de Equipamento inserido.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar incluir registro de Tipo de Equipamento. Contate o administrador.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdTipoEquipamento_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                GridEditFormItem editedItem = (GridEditFormItem)e.Item;
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {

                    EquipamentoTipo _equipamentoTipo = oUnitOfWork.EquipamentoTipoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["EquipamentoTipoID"].ToString()));                    
                    _equipamentoTipo.Descricao = (editedItem["colDescricao"].Controls[0] as TextBox).Text;
                    _equipamentoTipo.Observacao = (editedItem["colObservacao"].Controls[0] as TextBox).Text;                    
                    _equipamentoTipo.DataModificacao = DateTime.Now;
                    _equipamentoTipo.UsuarioModificadorID = int.Parse(Session["ssnLoggedUserID"].ToString());

                    oUnitOfWork.EquipamentoTipoREP.Atualizar(_equipamentoTipo);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de Tipo de Equipamento atualizado.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar atualizar registro de Tipo de Equipamento. Contate o administrador.", Enums.TipoNotificacao.Erro);
            }
        }
        protected void grdTipoEquipamento_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {   
                GridDataItem editedItem = (GridDataItem)e.Item;
                using (UnitOfWork oUnitOfWork = new UnitOfWork())
                {
                    EquipamentoTipo _equipamentoTipo = oUnitOfWork.EquipamentoTipoREP.BuscarPorID(int.Parse(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["EquipamentoTipoID"].ToString()));                    

                    oUnitOfWork.EquipamentoTipoREP.Remover(_equipamentoTipo);
                    oUnitOfWork.Save();
                }

                Utils.Notificar(ntfGeral, "Registro de Tipo de Equipamento removido.", Enums.TipoNotificacao.Informacao);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                Log.Trace(ex, true);
                Utils.Notificar(ntfGeral, "Falha ao tentar excluir registro de Tipo de Equipamento. Os vínculos com registros de Equipamento devem ser excluídos antes de tentar remover novamente.", Enums.TipoNotificacao.Erro);
            }
        }
    }
}