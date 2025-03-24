/*
Construir um programa que calcule, armazene e apresente em metros
por segundo o valor da velocidade de um projétil que percorre uma
distância de quilômetros a um espaço de tempo em minutos.
Utilize a fórmula:
VELOCIDADE = (DISTANCIA * 1000) / (TEMPO * 60)
 */
fun velocidadeProjetil(){
    println("Digite a distância em Km: ")
    val distanciaKm = readLine()?.toDoubleOrNull()
    println ("Digite o tempo em minutos: ")
    val tempoMin = readLine()?.toDoubleOrNull()
    val velocidade = (distanciaKm*1000) / (tempoMin*60)
    println("Velocidade do Projétil: $velocidade m/s" )
}

