fun exeTwoFer(name: String?) {
    val finalName = if (name.isNullOrBlank()) "you" else name
    println("Um para $finalName, um para mim.")
}

fun main() {
    print("Digite seu nome: ")
    val name = readLine()
    exeTwoFer(name)
}
