﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GPRSService.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebServiceSoap")]
    public interface WebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MarshalByRefObject))]
        string SaveData(string username, string password, string sqlstr, GPRSService.ServiceReference1.SqlParameter[] param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveDataV2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MarshalByRefObject))]
        string SaveDataV2(string username, string password, int EquipmentId, GPRSService.ServiceReference1.SqlParameter[] param);
        
        // CODEGEN: 参数“paramArray”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveDataV3", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MarshalByRefObject))]
        GPRSService.ServiceReference1.SaveDataV3Response SaveDataV3(GPRSService.ServiceReference1.SaveDataV3Request request);
        
        // CODEGEN: 参数“paramArray”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveDataV4", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MarshalByRefObject))]
        GPRSService.ServiceReference1.SaveDataV4Response SaveDataV4(GPRSService.ServiceReference1.SaveDataV4Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/QueryData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(MarshalByRefObject))]
        string[] QueryData(string username, string password, int EquipmentId);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class SqlParameter : DbParameter {
        
        private SqlCompareOptions compareInfoField;
        
        private string xmlSchemaCollectionDatabaseField;
        
        private string xmlSchemaCollectionOwningSchemaField;
        
        private string xmlSchemaCollectionNameField;
        
        private int localeIdField;
        
        private SqlDbType sqlDbTypeField;
        
        private object sqlValueField;
        
        private string udtTypeNameField;
        
        private string typeNameField;
        
        private int offsetField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public SqlCompareOptions CompareInfo {
            get {
                return this.compareInfoField;
            }
            set {
                this.compareInfoField = value;
                this.RaisePropertyChanged("CompareInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string XmlSchemaCollectionDatabase {
            get {
                return this.xmlSchemaCollectionDatabaseField;
            }
            set {
                this.xmlSchemaCollectionDatabaseField = value;
                this.RaisePropertyChanged("XmlSchemaCollectionDatabase");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string XmlSchemaCollectionOwningSchema {
            get {
                return this.xmlSchemaCollectionOwningSchemaField;
            }
            set {
                this.xmlSchemaCollectionOwningSchemaField = value;
                this.RaisePropertyChanged("XmlSchemaCollectionOwningSchema");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string XmlSchemaCollectionName {
            get {
                return this.xmlSchemaCollectionNameField;
            }
            set {
                this.xmlSchemaCollectionNameField = value;
                this.RaisePropertyChanged("XmlSchemaCollectionName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int LocaleId {
            get {
                return this.localeIdField;
            }
            set {
                this.localeIdField = value;
                this.RaisePropertyChanged("LocaleId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public SqlDbType SqlDbType {
            get {
                return this.sqlDbTypeField;
            }
            set {
                this.sqlDbTypeField = value;
                this.RaisePropertyChanged("SqlDbType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public object SqlValue {
            get {
                return this.sqlValueField;
            }
            set {
                this.sqlValueField = value;
                this.RaisePropertyChanged("SqlValue");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string UdtTypeName {
            get {
                return this.udtTypeNameField;
            }
            set {
                this.udtTypeNameField = value;
                this.RaisePropertyChanged("UdtTypeName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string TypeName {
            get {
                return this.typeNameField;
            }
            set {
                this.typeNameField = value;
                this.RaisePropertyChanged("TypeName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Offset {
            get {
                return this.offsetField;
            }
            set {
                this.offsetField = value;
                this.RaisePropertyChanged("Offset");
            }
        }
    }
    
    /// <remarks/>
    [System.FlagsAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum SqlCompareOptions {
        
        /// <remarks/>
        None = 1,
        
        /// <remarks/>
        IgnoreCase = 2,
        
        /// <remarks/>
        IgnoreNonSpace = 4,
        
        /// <remarks/>
        IgnoreKanaType = 8,
        
        /// <remarks/>
        IgnoreWidth = 16,
        
        /// <remarks/>
        BinarySort = 32,
        
        /// <remarks/>
        BinarySort2 = 64,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum SqlDbType {
        
        /// <remarks/>
        BigInt,
        
        /// <remarks/>
        Binary,
        
        /// <remarks/>
        Bit,
        
        /// <remarks/>
        Char,
        
        /// <remarks/>
        DateTime,
        
        /// <remarks/>
        Decimal,
        
        /// <remarks/>
        Float,
        
        /// <remarks/>
        Image,
        
        /// <remarks/>
        Int,
        
        /// <remarks/>
        Money,
        
        /// <remarks/>
        NChar,
        
        /// <remarks/>
        NText,
        
        /// <remarks/>
        NVarChar,
        
        /// <remarks/>
        Real,
        
        /// <remarks/>
        UniqueIdentifier,
        
        /// <remarks/>
        SmallDateTime,
        
        /// <remarks/>
        SmallInt,
        
        /// <remarks/>
        SmallMoney,
        
        /// <remarks/>
        Text,
        
        /// <remarks/>
        Timestamp,
        
        /// <remarks/>
        TinyInt,
        
        /// <remarks/>
        VarBinary,
        
        /// <remarks/>
        VarChar,
        
        /// <remarks/>
        Variant,
        
        /// <remarks/>
        Xml,
        
        /// <remarks/>
        Udt,
        
        /// <remarks/>
        Structured,
        
        /// <remarks/>
        Date,
        
        /// <remarks/>
        Time,
        
        /// <remarks/>
        DateTime2,
        
        /// <remarks/>
        DateTimeOffset,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DbParameter))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SqlParameter))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class MarshalByRefObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SqlParameter))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class DbParameter : MarshalByRefObject {
        
        private DbType dbTypeField;
        
        private ParameterDirection directionField;
        
        private bool isNullableField;
        
        private string parameterNameField;
        
        private byte precisionField;
        
        private byte scaleField;
        
        private int sizeField;
        
        private string sourceColumnField;
        
        private bool sourceColumnNullMappingField;
        
        private DataRowVersion sourceVersionField;
        
        private object valueField;
        
        public DbParameter() {
            this.directionField = ParameterDirection.Input;
            this.parameterNameField = "";
            this.sourceColumnField = "";
            this.sourceColumnNullMappingField = false;
            this.sourceVersionField = DataRowVersion.Current;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public DbType DbType {
            get {
                return this.dbTypeField;
            }
            set {
                this.dbTypeField = value;
                this.RaisePropertyChanged("DbType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        [System.ComponentModel.DefaultValueAttribute(ParameterDirection.Input)]
        public ParameterDirection Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
                this.RaisePropertyChanged("Direction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool IsNullable {
            get {
                return this.isNullableField;
            }
            set {
                this.isNullableField = value;
                this.RaisePropertyChanged("IsNullable");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string ParameterName {
            get {
                return this.parameterNameField;
            }
            set {
                this.parameterNameField = value;
                this.RaisePropertyChanged("ParameterName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public byte Precision {
            get {
                return this.precisionField;
            }
            set {
                this.precisionField = value;
                this.RaisePropertyChanged("Precision");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public byte Scale {
            get {
                return this.scaleField;
            }
            set {
                this.scaleField = value;
                this.RaisePropertyChanged("Scale");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
                this.RaisePropertyChanged("Size");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string SourceColumn {
            get {
                return this.sourceColumnField;
            }
            set {
                this.sourceColumnField = value;
                this.RaisePropertyChanged("SourceColumn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool SourceColumnNullMapping {
            get {
                return this.sourceColumnNullMappingField;
            }
            set {
                this.sourceColumnNullMappingField = value;
                this.RaisePropertyChanged("SourceColumnNullMapping");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        [System.ComponentModel.DefaultValueAttribute(DataRowVersion.Current)]
        public DataRowVersion SourceVersion {
            get {
                return this.sourceVersionField;
            }
            set {
                this.sourceVersionField = value;
                this.RaisePropertyChanged("SourceVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public object Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum DbType {
        
        /// <remarks/>
        AnsiString,
        
        /// <remarks/>
        Binary,
        
        /// <remarks/>
        Byte,
        
        /// <remarks/>
        Boolean,
        
        /// <remarks/>
        Currency,
        
        /// <remarks/>
        Date,
        
        /// <remarks/>
        DateTime,
        
        /// <remarks/>
        Decimal,
        
        /// <remarks/>
        Double,
        
        /// <remarks/>
        Guid,
        
        /// <remarks/>
        Int16,
        
        /// <remarks/>
        Int32,
        
        /// <remarks/>
        Int64,
        
        /// <remarks/>
        Object,
        
        /// <remarks/>
        SByte,
        
        /// <remarks/>
        Single,
        
        /// <remarks/>
        String,
        
        /// <remarks/>
        Time,
        
        /// <remarks/>
        UInt16,
        
        /// <remarks/>
        UInt32,
        
        /// <remarks/>
        UInt64,
        
        /// <remarks/>
        VarNumeric,
        
        /// <remarks/>
        AnsiStringFixedLength,
        
        /// <remarks/>
        StringFixedLength,
        
        /// <remarks/>
        Xml,
        
        /// <remarks/>
        DateTime2,
        
        /// <remarks/>
        DateTimeOffset,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum ParameterDirection {
        
        /// <remarks/>
        Input,
        
        /// <remarks/>
        Output,
        
        /// <remarks/>
        InputOutput,
        
        /// <remarks/>
        ReturnValue,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum DataRowVersion {
        
        /// <remarks/>
        Original,
        
        /// <remarks/>
        Current,
        
        /// <remarks/>
        Proposed,
        
        /// <remarks/>
        Default,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SaveDataV3", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SaveDataV3Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int EquipmentId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfSqlParameter")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public GPRSService.ServiceReference1.SqlParameter[][] paramArray;
        
        public SaveDataV3Request() {
        }
        
        public SaveDataV3Request(string username, string password, int EquipmentId, GPRSService.ServiceReference1.SqlParameter[][] paramArray) {
            this.username = username;
            this.password = password;
            this.EquipmentId = EquipmentId;
            this.paramArray = paramArray;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SaveDataV3Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SaveDataV3Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string SaveDataV3Result;
        
        public SaveDataV3Response() {
        }
        
        public SaveDataV3Response(string SaveDataV3Result) {
            this.SaveDataV3Result = SaveDataV3Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SaveDataV4", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SaveDataV4Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int EquipmentId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string[] TableArray;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfSqlParameter")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public GPRSService.ServiceReference1.SqlParameter[][] paramArray;
        
        public SaveDataV4Request() {
        }
        
        public SaveDataV4Request(string username, string password, int EquipmentId, string[] TableArray, GPRSService.ServiceReference1.SqlParameter[][] paramArray) {
            this.username = username;
            this.password = password;
            this.EquipmentId = EquipmentId;
            this.TableArray = TableArray;
            this.paramArray = paramArray;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SaveDataV4Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SaveDataV4Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string SaveDataV4Result;
        
        public SaveDataV4Response() {
        }
        
        public SaveDataV4Response(string SaveDataV4Result) {
            this.SaveDataV4Result = SaveDataV4Result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : GPRSService.ServiceReference1.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<GPRSService.ServiceReference1.WebServiceSoap>, GPRSService.ServiceReference1.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SaveData(string username, string password, string sqlstr, GPRSService.ServiceReference1.SqlParameter[] param) {
            return base.Channel.SaveData(username, password, sqlstr, param);
        }
        
        public string SaveDataV2(string username, string password, int EquipmentId, GPRSService.ServiceReference1.SqlParameter[] param) {
            return base.Channel.SaveDataV2(username, password, EquipmentId, param);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GPRSService.ServiceReference1.SaveDataV3Response GPRSService.ServiceReference1.WebServiceSoap.SaveDataV3(GPRSService.ServiceReference1.SaveDataV3Request request) {
            return base.Channel.SaveDataV3(request);
        }
        
        public string SaveDataV3(string username, string password, int EquipmentId, GPRSService.ServiceReference1.SqlParameter[][] paramArray) {
            GPRSService.ServiceReference1.SaveDataV3Request inValue = new GPRSService.ServiceReference1.SaveDataV3Request();
            inValue.username = username;
            inValue.password = password;
            inValue.EquipmentId = EquipmentId;
            inValue.paramArray = paramArray;
            GPRSService.ServiceReference1.SaveDataV3Response retVal = ((GPRSService.ServiceReference1.WebServiceSoap)(this)).SaveDataV3(inValue);
            return retVal.SaveDataV3Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GPRSService.ServiceReference1.SaveDataV4Response GPRSService.ServiceReference1.WebServiceSoap.SaveDataV4(GPRSService.ServiceReference1.SaveDataV4Request request) {
            return base.Channel.SaveDataV4(request);
        }
        
        public string SaveDataV4(string username, string password, int EquipmentId, string[] TableArray, GPRSService.ServiceReference1.SqlParameter[][] paramArray) {
            GPRSService.ServiceReference1.SaveDataV4Request inValue = new GPRSService.ServiceReference1.SaveDataV4Request();
            inValue.username = username;
            inValue.password = password;
            inValue.EquipmentId = EquipmentId;
            inValue.TableArray = TableArray;
            inValue.paramArray = paramArray;
            GPRSService.ServiceReference1.SaveDataV4Response retVal = ((GPRSService.ServiceReference1.WebServiceSoap)(this)).SaveDataV4(inValue);
            return retVal.SaveDataV4Result;
        }
        
        public string[] QueryData(string username, string password, int EquipmentId) {
            return base.Channel.QueryData(username, password, EquipmentId);
        }
    }
}
