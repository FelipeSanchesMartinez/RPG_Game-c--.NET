using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGame.Data;
using RpgGame.Enums;
using RpgGame.Interfaces;
using RpgGame.Models;
using RpgGame.Util;

namespace RpgGame.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly SQLContext _sqlContext;
        private readonly IPersonagemService _personageService;

        public PartidaService(SQLContext sqlContext, IPersonagemService personageService)
        {
            _sqlContext = sqlContext;
            _personageService = personageService;
        }


        public List<PartidaLog> ObterLogsPorPartidaId(long partidaId)
        {
           return _sqlContext.PartidaLog.AsNoTracking().Where(log => log.PartidaId == partidaId).ToList();
        }

        public List<Partida> ObterTodos()
        {
            return _sqlContext.Partida.AsNoTracking().ToList();
        }

        public Partida ObterPorId(long id)
        {
            return _sqlContext.Partida.AsNoTracking().FirstOrDefault(partida => partida.Id == id);
        }


        public Partida NovaPartida(string nomeJogador1, long personagem1Id, string nomeJogador2, long personagem2Id)
        {
            var personagem1 = _personageService.ObterPorId(personagem1Id);
            var personagem2 = _personageService.ObterPorId(personagem2Id);

            if (personagem1 == null || personagem2 == null) { return null; }


            DadoRpg dadoPrimeiroTurnoPersonagem1 = new DadoRpg(1, 20);
            DadoRpg dadoPrimeiroTurnoPersonagem2 = new DadoRpg(1, 20);

            int dadoPrimeiroTurnoResultadoPersonagem1 = 0;
            int dadoPrimeiroTurnoResultadoPersonagem2 = 0;

            while (dadoPrimeiroTurnoResultadoPersonagem1 == dadoPrimeiroTurnoResultadoPersonagem2)
            {
                dadoPrimeiroTurnoResultadoPersonagem1 = dadoPrimeiroTurnoPersonagem1.Jogar();
                dadoPrimeiroTurnoResultadoPersonagem2 = dadoPrimeiroTurnoPersonagem2.Jogar();
            }

            PartidaJogador partidaJogador1 = new PartidaJogador()
            {
                Nome = nomeJogador1,
                PersonagemId = personagem1Id,
                Vida = personagem1.Vida,
                PrimeiroTurno = dadoPrimeiroTurnoResultadoPersonagem1 > dadoPrimeiroTurnoResultadoPersonagem2,
                ResultadoDadoPrimeiroTurno = dadoPrimeiroTurnoResultadoPersonagem1,
                CriadoEm = DateTime.Now
            };

            PartidaJogador partidaJogador2 = new PartidaJogador()
            {
                Nome = nomeJogador2,
                PersonagemId = personagem2Id,
                Vida = personagem2.Vida,
                PrimeiroTurno = dadoPrimeiroTurnoResultadoPersonagem2 > dadoPrimeiroTurnoResultadoPersonagem1,
                ResultadoDadoPrimeiroTurno = dadoPrimeiroTurnoResultadoPersonagem2,
                CriadoEm = DateTime.Now
            };

            PartidaJogador partidaJogadorPrimeiroTurno = partidaJogador1.PrimeiroTurno == true ? partidaJogador1 : partidaJogador2;


            Partida novaPartida = new Partida()
            {
                Jogador1 = partidaJogador1,
                Jogador2 = partidaJogador2,
                JogadorTurno = partidaJogadorPrimeiroTurno,
                Turno = PartidaTurno.Ataque,
                CriadoEm = DateTime.Now
            };

            _sqlContext.Partida.Add(novaPartida);
            _sqlContext.SaveChanges();

            return novaPartida;
        }


        public Partida TurnoAtaque(long partidaId)
        {
            Partida partida = _sqlContext.Partida
                .AsNoTracking()
                .Include(partida => partida.Jogador1)
                    .ThenInclude(jogador1 => jogador1.Personagem)
                 .Include(partida => partida.Jogador2)
                    .ThenInclude(jogador2 => jogador2.Personagem)
                 .Include(partida => partida.JogadorTurno)
                    .ThenInclude(jogadorTurno => jogadorTurno.Personagem)
                .FirstOrDefault(partida => partida.Id == partidaId);

            if (partida == null) { return null; }

            if (partida.Finalizado == true) { return null; }

            if (partida.Turno != PartidaTurno.Ataque) { return null; }

            Personagem personagem = partida.JogadorTurno.Personagem;

            DadoRpg dado = new DadoRpg(1, 12);
            int dadoResultado = dado.Jogar();
            int resultado = dadoResultado + personagem.Forca + personagem.Agilidade;


            PartidaLog partidaLog = new PartidaLog()
            {
                PartidaId = partidaId,
                PartidaJogadorId = partida.PartidaJogadorTurnoId,
                Turno = partida.Turno,
                DadoResultado = dadoResultado,
                Resultado = resultado,
                Atributo = personagem.Forca,
                Agilidade = personagem.Agilidade,
                CriadoEm = DateTime.Now
            };

            partida.Turno = PartidaTurno.Defesa;
            partida.PartidaJogadorTurnoId = partida.PartidaJogador1Id == partida.PartidaJogadorTurnoId ? partida.PartidaJogador2Id : partida.PartidaJogador1Id;

            _sqlContext.Partida.Update(partida);
            _sqlContext.PartidaLog.Add(partidaLog);

            _sqlContext.SaveChanges();

            return partida;
        }

        public Partida TurnoDefesa(long partidaId)
        {
            Partida partida = _sqlContext.Partida
                .AsNoTracking()
                .Include(partida => partida.Jogador1)
                    .ThenInclude(jogador1 => jogador1.Personagem)
                 .Include(partida => partida.Jogador2)
                    .ThenInclude(jogador2 => jogador2.Personagem)
                 .Include(partida => partida.JogadorTurno)
                    .ThenInclude(jogadorTurno => jogadorTurno.Personagem)
                 .Include(partida => partida.Logs)
                .FirstOrDefault(partida => partida.Id == partidaId);

            if (partida == null) { return null; }

            if (partida.Finalizado == true) { return null; }

            if (partida.Turno != PartidaTurno.Defesa) { return null; }

            Personagem personagem = partida.JogadorTurno.Personagem;

            PartidaLog ultimoLogAtaque = partida.Logs.OrderBy(log => log.CriadoEm).LastOrDefault();

            if (ultimoLogAtaque.Turno != PartidaTurno.Ataque) { return null; }

            DadoRpg dado = new DadoRpg(1, 12);
            int dadoResultado = dado.Jogar();
            int resultado = dadoResultado + personagem.Defesa + personagem.Agilidade;

            bool defendeu = resultado >= ultimoLogAtaque.Resultado;

            PartidaLog partidaLog = new PartidaLog()
            {
                PartidaId = partidaId,
                PartidaJogadorId = partida.PartidaJogadorTurnoId,
                Turno = partida.Turno,
                DadoResultado = dadoResultado,
                Resultado = resultado,
                Atributo = personagem.Defesa,
                Agilidade = personagem.Agilidade,
                Defendeu = defendeu,
                CriadoEm = DateTime.Now
            };

            partida.Turno = PartidaTurno.Ataque;
            partida.PartidaJogadorTurnoId = partida.PartidaJogador1Id == partida.PartidaJogadorTurnoId ? partida.PartidaJogador2Id : partida.PartidaJogador1Id;

            _sqlContext.Partida.Update(partida);
            _sqlContext.PartidaLog.Add(partidaLog);

            _sqlContext.SaveChanges();

            return partida;
        }

        public Partida CalcularDano(long partidaId)
        {
            Partida partida = _sqlContext.Partida
                .AsNoTracking()
                .Include(partida => partida.Jogador1)
                    .ThenInclude(jogador1 => jogador1.Personagem)
                 .Include(partida => partida.Jogador2)
                    .ThenInclude(jogador2 => jogador2.Personagem)
                 .Include(partida => partida.JogadorTurno)
                    .ThenInclude(jogadorTurno => jogadorTurno.Personagem)
                 .Include(partida => partida.Logs)
                    .ThenInclude(log => log.Jogador)
                        .ThenInclude(jogador => jogador.Personagem)
                .FirstOrDefault(partida => partida.Id == partidaId);

            if (partida == null) { return null; }

            if (partida.Finalizado == true) { return null; }

            if (partida.Turno != PartidaTurno.Ataque) { return null; }

            Personagem personagem = partida.JogadorTurno.Personagem;

            PartidaLog ultimoLogDefesa = partida.Logs.OrderBy(log => log.CriadoEm).LastOrDefault();

            if (ultimoLogDefesa.Dano != null) { return null; }

            if (ultimoLogDefesa.Turno != PartidaTurno.Defesa) { return null; }

            PartidaLog ultimoLogAtaque = partida.Logs
                                            .Where(log => log.Turno == PartidaTurno.Ataque)
                                            .OrderBy(log => log.CriadoEm)
                                            .LastOrDefault();

            if (ultimoLogDefesa.Defendeu)
            {
         
                ultimoLogDefesa.Dano = 0;

                _sqlContext.PartidaLog
                    .Where(log => log.Id == ultimoLogDefesa.Id)
                    .ExecuteUpdate(opt => opt.SetProperty(log => log.Dano, 0));

                _sqlContext.SaveChanges();
                return partida;
            }

            PartidaJogador partidaJogadorAtaque = ultimoLogAtaque.Jogador;
            Personagem personagemAtaque = ultimoLogAtaque.Jogador.Personagem;

            DadoRpg dado = new DadoRpg(personagemAtaque.QtdDados, personagemAtaque.FacesDado);
            int dadoResultado = dado.Jogar();
            int resultado = dadoResultado + personagemAtaque.Forca;

            PartidaJogador partidaJogadorDefesa = ultimoLogDefesa.Jogador;

            int danoTotalLogs = partida.Logs
                 .Where(log => log.PartidaJogadorId == partidaJogadorDefesa.Id && log.Turno == PartidaTurno.Defesa)
                 .Sum(log => log.Dano) ?? 0;

            int danoTotal = resultado + danoTotalLogs;


            _sqlContext.PartidaLog
                .Where(log => log.Id == ultimoLogDefesa.Id)
                .ExecuteUpdate(update => update.SetProperty(log => log.DanoDadoResultado, dadoResultado)
                                               .SetProperty(log => log.Dano, resultado)
                                               .SetProperty(log => log.DanoTotal, danoTotal));


            int calculoVida = partidaJogadorDefesa.Vida - resultado;

            int partidaJogadorDefesaVida = calculoVida < 0 ? 0 : calculoVida;

            _sqlContext.PartidaJogador
                .Where(partidaJogador => partidaJogador.Id == partidaJogadorDefesa.Id)
                .ExecuteUpdate(update => update.SetProperty(partidaJogador => partidaJogador.Vida, partidaJogadorDefesaVida));

            if (partidaJogadorDefesaVida == 0)
            {
                partida.Finalizado = true;
                partida.PartidaJogadorVencedorId = partidaJogadorAtaque.Id;

                _sqlContext.Partida
                    .Where(partida => partida.Id == partidaId)
                    .ExecuteUpdate(update => update.SetProperty(partida => partida.Finalizado, true)
                                                    .SetProperty(partida => partida.PartidaJogadorVencedorId, partidaJogadorAtaque.Id));
            }

            _sqlContext.SaveChanges();

            return _sqlContext.Partida.AsNoTracking().FirstOrDefault(partida => partida.Id == partidaId);
        }
    }
}
