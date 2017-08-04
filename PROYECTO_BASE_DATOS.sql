
/****************************************ADMISION********************************************************/
use ProyectoIF5100_Grupo7

CREATE TABLE ADMISION(
	num_admision int identity(1,1) constraint PK_ADMISION PRIMARY KEY,
	fecha date default getDate(),
	num_paciente int constraint fk_paciente_dmision FOREIGN KEY REFERENCES PACIENTE (numero_p),
	nombre_h varchar(50) ,
	num_sala int,
	constraint fk_sala_dmision FOREIGN KEY (num_sala, nombre_h) REFERENCES SALA(num_sala, nombre_h)
)

USE ProyectoIF5100_Grupo7
go
CREATE PROCEDURE [dbo].[InsertarAdmision](
		@num_admision int,
		@fecha date,
		@num_paciente int,
		@nombre_h varchar(50),
		@num_sala int)
	AS
BEGIN
	INSERT INTO ADMISION(num_paciente, nombre_h, num_sala)
    VALUES (RTRIM(@num_paciente), RTRIM(@nombre_h), RTRIM(@num_sala))
    SELECT @num_admision = @@IDENTITY
END

GO

USE ProyectoIF5100_Grupo7
GO
CREATE PROCEDURE [dbo].[ActualizaAdmision](
	@num_admision int, 
	@num_paciente int, 
	@nombre_h varchar(50), 
	@num_sala int)
AS
BEGIN

	UPDATE ADMISION
	SET num_paciente = @num_paciente,
		nombre_h = @nombre_h,
		num_sala = @num_sala
	WHERE num_admision = @num_admision

END

GO

USE ProyectoIF5100_Grupo7
GO
CREATE PROCEDURE [dbo].[EliminaAdmision](
	@num_admision int)
AS
BEGIN

	DELETE ADMISION
	WHERE num_admision = @num_admision

END

GO
/*******************************************DIAGNOSTICO PACIENTE**********************************************/

USE ProyectoIF5100_Grupo7
go
CREATE PROCEDURE [dbo].[InsertarDiagnosticoPaciente](
		@numero_p int,
		@DNI_m int,
		@diagnostico varchar(200),
		@estado_paciente varchar(15),
		@fecha_cita date)
	AS
BEGIN
	INSERT INTO DIAGNOSTICO_PACIENTE(numero_p, DNI_m, diagnóstico, estado_paciente, fecha_cita)
    VALUES (RTRIM(@numero_p), RTRIM(@DNI_m), RTRIM(@diagnostico), RTRIM(@estado_paciente), RTRIM(@fecha_cita))
END

GO

USE ProyectoIF5100_Grupo7
GO
CREATE PROCEDURE [dbo].[ActualizaDiagnosticoPaciente](
		@numero_p int,
		@DNI_m int,
		@diagnostico varchar(200),
		@estado_paciente varchar(15),
		@fecha_cita date)
AS
BEGIN

	UPDATE DIAGNOSTICO_PACIENTE
	SET numero_p = @numero_p,
		DNI_m = @DNI_m,
		diagnóstico = @diagnostico,
		estado_paciente = @estado_paciente,
		fecha_cita = @fecha_cita
	WHERE numero_p = @numero_p and fecha_cita = @fecha_cita

END

GO

USE ProyectoIF5100_Grupo7
GO
CREATE PROCEDURE [dbo].[EliminaDiagnosticoPaciente](
	@numero_p int, 
	@fecha_cita date)
AS
BEGIN

	DELETE DIAGNOSTICO_PACIENTE
	WHERE numero_p = @numero_p and fecha_cita = @fecha_cita

END

GO
/**************************************PROCESOS NO BASICOS**********************************************/

CREATE PROCEDURE Proc_Reemplazo_Medico (
	@DNI_m_viejo int,
	@DNI_m int, 
	@especialidad varchar(20), 
	@fecha_ingreso date,
	@monto_especialidad int,
	@estado varchar(10))
AS
DECLARE	
@especialidad_viejo varchar(20)

BEGIN
	select @especialidad_viejo=(select especialidad from MEDICO where DNI_m= @DNI_m_viejo)
	IF(@especialidad_viejo = @especialidad)begin
		
		Insert into MEDICO(DNI_m,especialidad, fecha_ingreso, monto_especialidad,estado)
		values(@DNI_m, @especialidad, @fecha_ingreso, @monto_especialidad, @estado)

		Update HORARIO_MEDICO set DNI_m = @DNI_m where @DNI_m_viejo= DNI_m

		Update CITAS_PACIENTE set DNI_m = @DNI_m where @DNI_m_viejo= DNI_m

		Update MEDICO set estado = 'no vigente' where @DNI_m_viejo = DNI_m
		
		if(@@error <> 0)begin
			print('Ha ocurrido un error a la hora de reemplazar un medico')
		end
	end

END
 
GO
/*Select cita.fecha ,horasCitas.*, cita.nombre_h from horasCitas inner join cita on cita.hora = horasCitas.hora 
where  cita.nombre_h = 'Max Peralta'  and DNI_m = 307670628*/

CREATE PROCEDURE Proc_Reprogramar_Cita (@fecha date, @hospital varchar, @dniMedico int, @motivo varchar(50))
AS

/*DECLARE  
	@hora time(7)
BEGIN
	if(@dniMedico!='')begin
		Select (cita.fecha)as 'fecha', (horasCitas.hora)as 'hora', (cita.nombre_h)as 'hospital', (cita.DNI_m)as 'medico'
		into #citasDisponiblesPorDoctor 
		from horasCitas inner join cita on cita.hora != horasCitas.hora 
		where  cita.nombre_h = @hospital and cita.fecha= @fecha and DNI_m = @dniMedico

		while exists(Select * from #citasDisponiblesPorDoctor)begin
			set rowcount 1
			select fecha, hora= @hora, hospital, medico from #citasDisponiblesPorDoctor 

			update
		end
	end*/
END


