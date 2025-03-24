fun romanoParaInteiro(s: String): Int {
    val valoresRomanos = mapOf(
        'I' to 1, 'V' to 5, 'X' to 10, 'L' to 50,
        'C' to 100, 'D' to 500, 'M' to 1000
    )

    var total = 0
    var anterior = 0

    for (c in s.uppercase()) {
        val atual = valoresRomanos[c] ?: 0
        if (atual > anterior) {
            total += atual - 2 * anterior // Subtrai o dobro do anterior porque já havia sido somado antes
        } else {
            total += atual
        }
        anterior = atual
    }
    return total
}

fun main() {
    print("Digite um número em algarismos romanos: ")
    val entrada = readLine()?.trim()

    if (entrada.isNullOrEmpty() || !entrada.all { it in "IVXLCDMivxlcdm" }) {
        println("Entrada inválida. Digite apenas caracteres romanos válidos (I, V, X, L, C, D, M).")
        return
    }

    val resultado = romanoParaInteiro(entrada)
    println("O valor numérico de \"$entrada\" é: $resultado")
}
