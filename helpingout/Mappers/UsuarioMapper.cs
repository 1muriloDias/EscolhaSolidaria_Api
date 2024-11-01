using helpingout.Models;
using helpingout.Dtos;
using helpingout.Dtos.Usuario;

namespace helpingout.Mappers
{
	public static class UsuarioMapper
	{
		public static Usuario ToUsuarioFromCreateDTO(this CreateUsuarioRequestDto dto)
		{
			return new Usuario
			{
				
				Nome = dto.Nome,
				
			};
		}

		public static UsuarioDto ToUsuarioDto(this Usuario usuario)
		{
			return new UsuarioDto
			{
				Id = usuario.IdUsuario,
				Nome = usuario.Nome,
			
			};
		}
	}
}
