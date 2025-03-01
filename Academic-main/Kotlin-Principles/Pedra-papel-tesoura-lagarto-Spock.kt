fun main() {
    print("Jogador 1: ")
    val jogador1 = readLine()!!.lowercase()
    print("Jogador 2: ")
    val jogador2 = readLine()!!.lowercase()
    println(determinarVencedor(jogador1, jogador2))
}

fun determinarVencedor(jogador1: String, jogador2: String): String {
    val regras = mapOf(
            "tesoura" to listOf("papel", "lagarto"),
            "papel" to listOf("pedra", "spock"),
            "pedra" to listOf("lagarto", "tesoura"),
            "lagarto" to listOf("spock", "papel"),
            "spock" to listOf("tesoura", "pedra")
    )
    return when {
        jogador1 == jogador2 -> "Empate!"
        regras[jogador1]?.contains(jogador2) == true -> "Jogador 1 vence!"
        else -> "Jogador 2 vence!"
    }
}