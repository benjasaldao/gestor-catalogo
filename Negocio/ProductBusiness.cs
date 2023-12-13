using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class ProductBusiness
    {
        private DataAccess data;
        
        public ProductBusiness() 
        {
            data = new DataAccess();
        }

        public List<Product> list()
        {
            List<Product> list = new List<Product>();

            try
            {
                data.setQuery("select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Codigo"];
                    product.name = (string)data.Reader["Nombre"];
                    product.description = (string)data.Reader["Descripcion"];
                    product.imageUrl = (string)data.Reader["ImagenUrl"];
                    product.price = (decimal)data.Reader["Precio"];

                    product.brand = new Brand((int)data.Reader["IdMarca"], (string)data.Reader["Marca"]); 
                    product.category = new Category((int)data.Reader["IdCategoria"], (string)data.Reader["Categoria"]);

                    list.Add(product);
                }

                return list;
            }
            catch (Exception ex)
            { 
                throw ex;
            } 
            finally 
            {
                data.closeConnection();
            }

           

        }

        public void add(Product product)
        {
            try
            {
                data.setQuery("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@code, @name, @description, @brandId, @categoryId, @img, @price)");
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@img", product.imageUrl);
                data.setParam("@brandId", product.brand.id);
                data.setParam("@categoryId", product.category.id);
                data.setParam("@price", product.price);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }
    
        public void update(Product product)
        {
            try
            {
                data.setQuery("Update ARTICULOS set Codigo = @code, Nombre = @name, Descripcion = @description, ImagenUrl = @img, IdMarca = @brandId, IdCategoria = @categoryId, Precio = @price where Id = @id ");
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@img", product.imageUrl);
                data.setParam("@brandId", product.brand.id);
                data.setParam("@categoryId", product.category.id);
                data.setParam("@price", product.price);
                data.setParam("@id", product.id);

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }

        public void delete(Product product) 
        {
            try
            {
                data.setQuery("Delete ARTICULOS where Id = @id");
                data.setParam("@id", product.id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }
    }
}
