fun fizzBuzz(start: Int, end: Int) {
    for (num in start..end) {
        when {
            num % 3 == 0 && num % 5 == 0 -> println("FizzBuzz")
            num % 3 == 0 -> println("Fizz")
            num % 5 == 0 -> println("Buzz")
            else -> println(num)
        }
    }
}

fun main() {
    println("Informe o número inicial: ")
    val start = readLine()?.toIntOrNull()

    println("Informe o número final: ")
    val end = readLine()?.toIntOrNull()

    if (start == null || end == null) {
        println("Entrada inválida. Certifique-se de digitar números inteiros.")
        return
    }

    if (end <= start) {
        println("Erro: O número final deve ser maior que o número inicial.")
        return
    }

    fizzBuzz(start, end)
}
