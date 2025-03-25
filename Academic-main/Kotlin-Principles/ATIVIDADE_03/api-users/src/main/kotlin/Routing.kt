package umfg

import io.ktor.http.*
import io.ktor.server.application.*
import io.ktor.server.request.*
import io.ktor.server.response.*
import io.ktor.server.routing.*
import umfg.application.payloads.CreateUserPayload
import umfg.application.responses.UserCreatedResponse
import umfg.infra.repository.UserRepository

fun Application.configureRouting(userRepository: UserRepository) {
    routing {
        // Rota simples de teste
        get("/") {
            call.respondText("Hello World!")
        }

        // Rota para criar usuário
        post("/users") {
            val payload = call.receive<CreateUserPayload>()

            // Validações
            val errors = mutableListOf<String>()

            if (payload.name.isBlank()) {
                errors.add("O nome não pode estar vazio.")
            }
            if (payload.age < 0) {
                errors.add("A idade não pode ser negativa.")
            }

            if (errors.isNotEmpty()) {
                call.respond(HttpStatusCode.BadRequest, mapOf("errors" to errors))
                return@post
            }

            val id = userRepository.create(payload)
            call.respond(HttpStatusCode.Created, UserCreatedResponse(id))
        }

        put("/users/{id}") {
            val id = call.parameters["id"]?.toIntOrNull()
            if (id == null) {
                call.respond(HttpStatusCode.BadRequest, mapOf("error" to "ID inválido!"))
                return@put
            }

            val payload = call.receive<CreateUserPayload>()

            // Validações
            val errors = mutableListOf<String>()

            if (payload.name.isBlank()) {
                errors.add("O nome não pode estar vazio.")
            }
            if (payload.age < 0) {
                errors.add("A idade não pode ser negativa.")
            }

            if (errors.isNotEmpty()) {
                call.respond(HttpStatusCode.BadRequest, mapOf("errors" to errors))
                return@put
            }

            // Tenta atualizar o usuário
            val updatedUser = userRepository.update(id, payload)

            if (updatedUser != null) {
                call.respond(HttpStatusCode.OK, updatedUser)
            } else {
                call.respond(HttpStatusCode.NotFound, mapOf("error" to "Usuário não encontrado."))
            }
        }


        // Rota para buscar um usuário pelo ID
        get("/users/{id}") {
            val id = call.parameters["id"]?.toIntOrNull()
            if (id == null) {
                call.respond(HttpStatusCode.BadRequest, mapOf("error" to "ID inválido!"))
                return@get
            }

            val user = userRepository.findById(id)
            if (user != null) {
                call.respond(HttpStatusCode.OK, user)
            } else {
                call.respond(HttpStatusCode.NotFound, mapOf("error" to "Usuário não encontrado."))
            }
        }

        // Nova rota para listar todos os usuários
        get("/users") {
            val users = userRepository.findAll()
            if (users.isNotEmpty()) {
                call.respond(HttpStatusCode.OK, users)
            } else {
                call.respond(HttpStatusCode.NotFound, mapOf("error" to "Nenhum usuário encontrado."))
            }
        }

        delete("/users/{id}") {
            val id = call.parameters["id"]?.toIntOrNull()

            if (id == null) {
                call.respond(HttpStatusCode.BadRequest, mapOf("error" to "ID inválido!"))
                return@delete
            }

            val deleted = userRepository.delete(id)

            if (deleted) {
                call.respond(HttpStatusCode.NoContent) // 204 No Content quando excluído com sucesso
            } else {
                call.respond(HttpStatusCode.NotFound, mapOf("error" to "Usuário não encontrado."))
            }
        }

    }
}
