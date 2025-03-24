package umfg.infra.repository

import kotlinx.coroutines.Dispatchers
import org.jetbrains.exposed.sql.SchemaUtils
import org.jetbrains.exposed.sql.Table
import org.jetbrains.exposed.sql.insert
import org.jetbrains.exposed.sql.selectAll
import org.jetbrains.exposed.sql.transactions.experimental.newSuspendedTransaction
import org.jetbrains.exposed.sql.transactions.transaction
import umfg.DatabaseFactory
import umfg.application.payloads.CreateUserPayload

class UserRepository {

    private val database = DatabaseFactory.connect()

    object UserTable : Table() {
        val id = integer("id").autoIncrement()
        val name = varchar("name", length = 50)
        val age = integer("age")
        override val primaryKey = PrimaryKey(id)
    }

    init {
        transaction(database) {
            SchemaUtils.create(UserTable)
        }
    }

    suspend fun create(payload: CreateUserPayload): Int {
        return newSuspendedTransaction(Dispatchers.IO) {
            UserTable.insert {
                it[name] = payload.name
                it[age] = payload.age
            }[UserTable.id]
        }
    }

    suspend fun findById(id: Int): User? {
        return newSuspendedTransaction(Dispatchers.IO) {
            UserTable.selectAll()
                .where { UserTable.id eq id }
                .map {
                    User(
                        id = it[UserTable.id],
                        name = it[UserTable.name],
                        age = it[UserTable.age]
                    )
                }.singleOrNull()
        }
    }


}