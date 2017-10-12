using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sigmeh.Model;


namespace Sigmeh.Repository
{
    public class UnitOfWork : IDisposable
    {
        #region campos e variáveis
        private readonly EntitiesModel _context;
        private EntidadeREP _entidadeREP;
        private CanalComunicacaoREP _canalComunicacaoREP;
        private CanalComunicacaoTipoREP _canalComunicacaoTipoREP;        
        private EntidadeTipoREP _entidadeTipoREP;
        private TelefoneREP _telefoneREP;
        private EnderecoREP _enderecoREP;
        private EnderecoTipoREP _enderecoTipoREP;
        private EquipamentoREP _equipamentoREP;        
        private EquipamentoTipoREP _equipamentoTipoREP;        
        private RegistroManutencaoREP _registroManutencao;        
        private RegistroManutencaoArquivoREP _RegistroManutencaoArquivo;
        private ManutencaoTipoREP _manutencaoTipo;
        private ManutencaoStatusREP _manutencaoStatus;
        private PeriodicidadeREP _periodicidade;
        private ItemManutencaoREP _itemManutencao;
        private UsuarioREP _usuario;
        #endregion

        #region construtor
        public UnitOfWork()
        {
            _context = new EntitiesModel();            
        }
        #endregion

        #region propriedades (Repositórios)
        public EntidadeREP EntidadeREP
        {
            get
            {
                if (this._entidadeREP == null)
                    this._entidadeREP = new EntidadeREP(_context);
                return _entidadeREP;
            }
        }
        public CanalComunicacaoREP CanalComunicacaoREP
        {
            get 
            {
                if (this._canalComunicacaoREP == null)
                    this._canalComunicacaoREP = new CanalComunicacaoREP(_context);
                return _canalComunicacaoREP;
            }
        }
        public CanalComunicacaoTipoREP CanalComunicacaoTipoREP
        {
            get
            {
                if (this._canalComunicacaoTipoREP == null)
                    this._canalComunicacaoTipoREP = new CanalComunicacaoTipoREP(_context);
                return _canalComunicacaoTipoREP;
            }
        }        
        public EntidadeTipoREP EntidadeTipoREP
        {
            get
            {
                if (this._entidadeTipoREP == null)
                    this._entidadeTipoREP = new EntidadeTipoREP(_context);
                return _entidadeTipoREP;
            }
        }
        public TelefoneREP TelefoneREP
        {
            get
            {
                if (this._telefoneREP == null)
                    this._telefoneREP = new TelefoneREP(_context);
                return _telefoneREP;
            }
        }
        public EnderecoREP EnderecoREP
        {
            get
            {
                if (this._enderecoREP == null)
                    this._enderecoREP = new EnderecoREP(_context);
                return _enderecoREP;
            }
        }
        public EnderecoTipoREP EnderecoTipoREP
        {
            get
            {
                if (this._enderecoTipoREP == null)
                    this._enderecoTipoREP = new EnderecoTipoREP(_context);
                return _enderecoTipoREP;
            }
        }
        public EquipamentoREP EquipamentoREP
        {
            get
            {
                if (this._equipamentoREP == null)
                    this._equipamentoREP = new EquipamentoREP(_context);
                return _equipamentoREP;
            }
        }        
        public EquipamentoTipoREP EquipamentoTipoREP
        {
            get
            {
                if (this._equipamentoTipoREP == null)
                    this._equipamentoTipoREP = new EquipamentoTipoREP(_context);
                return _equipamentoTipoREP;
            }
        }        
        public RegistroManutencaoREP RegistroManutencaoREP
        {
            get
            {
                if (this._registroManutencao == null)
                    this._registroManutencao = new RegistroManutencaoREP(_context);
                return _registroManutencao;
            }
        }        
        public RegistroManutencaoArquivoREP RegistroManutencaoArquivoREP
        {
            get
            {
                if (this._RegistroManutencaoArquivo == null)
                    this._RegistroManutencaoArquivo = new RegistroManutencaoArquivoREP(_context);
                return _RegistroManutencaoArquivo;
            }
        }
        public ManutencaoTipoREP ManutencaoTipoREP
        {
            get
            {
                if (this._manutencaoTipo == null)
                    this._manutencaoTipo = new ManutencaoTipoREP(_context);
                return _manutencaoTipo;
            }
        }
        public ManutencaoStatusREP ManutencaoStatusREP
        {
            get
            {
                if (this._manutencaoStatus == null)
                    this._manutencaoStatus = new ManutencaoStatusREP(_context);
                return _manutencaoStatus;
            }
        }
        public PeriodicidadeREP PeriodicidadeREP
        {
            get
            {
                if (this._periodicidade == null)
                    this._periodicidade = new PeriodicidadeREP(_context);
                return _periodicidade;
            }
        }
        public ItemManutencaoREP ItemManutencaoREP
        {
            get
            {
                if (this._itemManutencao == null)
                    this._itemManutencao = new ItemManutencaoREP(_context);
                return _itemManutencao;
            }
        }
        public UsuarioREP UsuarioREP
        {
            get
            {
                if (this._usuario == null)
                    this._usuario = new UsuarioREP(_context);
                return _usuario;
            }
        }        
        #endregion

        #region métodos da classe
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
