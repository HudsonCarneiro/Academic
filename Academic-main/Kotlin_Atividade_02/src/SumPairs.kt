fun sumEvenNumbers(start: Int, end: Int): Int {
    var sum = 0
    for (num in start..end) {
        if (num % 2 == 0) {
            sum += num
        }
    }
    return sum
}

fun main() {
    print("Informe o número inicial: ")
    val start = readLine()?.toIntOrNull()

    print("Informe o número final: ")
    val end = readLine()?.toIntOrNull()

    if (start == null || end == null) {
        println("Entrada inválida. Certifique-se de digitar números inteiros.")
        return
    }

    if (end < start) {
        println("Erro: O número final deve ser maior ou igual ao número inicial.")
        return
    }

    val sum = sumEvenNumbers(start, end)
    println("A soma dos números pares no intervalo de $start a $end é: $sum")
}
