drop procedure spCarregarVotos

go

create procedure spCarregarVotos
as begin
	select	C.NomeCandidato,
			C.NomeVice,
			count(V.QuantidadeVotos) QuantidadeVotos
	from Votos V
		inner join Candidato C on
			V.IdCandidato = C.IdCandidato
group by C.NomeCandidato, C.NomeVice
end