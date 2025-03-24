fun somaQuadrado{
    println("Digite o primeiro número: ")
    val a = readLine()?.toIntOrNull()

    println("Digite o segundo número: ")
    val b = readLine()?.toIntOrNull()

    println("Digite o terceiro número: ")
    val c = readLine()?.toIntOrNull()

    if (a != null && b != null && c != null) {
        val soma = a * a + b * b + c * c
        println("A soma dos quadrados é: $soma")
    } else {
        println("Entrada inválida! Certifique-se de digitar apenas números inteiros.")
    }
}

