package umfg

import io.ktor.server.application.*
import io.ktor.server.netty.EngineMain
import umfg.infra.repository.UserRepository

fun main(args: Array<String>) {
    EngineMain.main(args)
}

fun Application.module() {
    // Inicializa conexão com o banco de dados
    DatabaseFactory.connect()

    // Cria uma instância do UserRepository
    val userRepository = UserRepository()

    // Configura serialização e rotas
    configureSerialization()
    configureRouting(userRepository)
}
