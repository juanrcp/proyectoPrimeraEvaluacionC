namespace proyectoFinalEvaluacionC.Models.DTOs
{
    public class ProductoDTO
    {
        //Construimos la clase correspondiente para hacer los productos

        //Atributos
        private int id_producto;
        private String md_uuid;
        private String? md_fch;
        private String cod_producto;
        private String? nombre_producto;
        private String? tipo_producto_origen;
        private String? tipo_producto_clase;
        private String? des_producto;
        private String? fch_alta_producto;
        private String? fch_baja_producto;

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Md_uuid { get => md_uuid; set => md_uuid = value; }
        public string Md_fch { get => md_fch; set => md_fch = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public string Tipo_producto_origen { get => tipo_producto_origen; set => tipo_producto_origen = value; }
        public string Tipo_producto_clase { get => tipo_producto_clase; set => tipo_producto_clase = value; }
        public string Des_producto { get => des_producto; set => des_producto = value; }
        public string Fch_alta_producto { get => fch_alta_producto; set => fch_alta_producto = value; }
        public string Fch_baja_producto { get => fch_baja_producto; set => fch_baja_producto = value; }

        public ProductoDTO(int id_producto, string md_uuid, string? md_fch, string cod_producto, string? nombre_producto, string? tipo_producto_origen, string? tipo_producto_clase, string? des_producto, string? fch_alta_producto, string? fch_baja_producto)
        {
            Id_producto = id_producto;
            Md_uuid = md_uuid;
            Md_fch = md_fch;
            Cod_producto = cod_producto;
            Nombre_producto = nombre_producto;
            Tipo_producto_origen = tipo_producto_origen;
            Tipo_producto_clase = tipo_producto_clase;
            Des_producto = des_producto;
            Fch_alta_producto = fch_alta_producto;
            Fch_baja_producto = fch_baja_producto;
            Id_producto = id_producto;
            Md_uuid = md_uuid;
            Md_fch = md_fch;
            Cod_producto = cod_producto;
            Nombre_producto = nombre_producto;
            Tipo_producto_origen = tipo_producto_origen;
            Tipo_producto_clase = tipo_producto_clase;
            Des_producto = des_producto;
            Fch_alta_producto = fch_alta_producto;
            Fch_baja_producto = fch_baja_producto;
        }
    }
}
