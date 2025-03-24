package umfg

import io.ktor.http.*
import io.ktor.server.application.*
import io.ktor.server.request.*
import io.ktor.server.response.*
import io.ktor.server.routing.*
import umfg.application.payloads.CreateUserPayload
import umfg.application.responses.UserCreatedResponse
import umfg.infra.repository.UserRepository

fun Application.configureRouting() {
    routing {
        val repository = UserRepository()
        get("/") {
            call.respondText("Hello World!")
        }
        post("/users") {
            val payload = call.receive<CreateUserPayload>()
            val id = repository.create(payload)
            val response = UserCreatedResponse(id)
            call.respond(HttpStatusCode.Created, response)
        }
        get("/users/{id}") {
            val id: Int = call.parameters["id"]?.toInt()
                ?: throw IllegalArgumentException("ID deve ser informado!")

            val user = repository.findById(id)
            if (user != null) {
                call.respond(HttpStatusCode.OK, user)
            } else {
                call.respond(HttpStatusCode.NotFound)
            }
        }
    }
}
