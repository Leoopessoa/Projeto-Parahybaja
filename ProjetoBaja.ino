
int analog, velocidade, rpm, contador = 0, gasolina = 30, teste;
char rx;

void setup() {
  Serial.begin(9600);
}

void loop() {

   if(gasolina >= 1){ // Faz a gasolina variar com base no tempo
    contador++;
    if(contador>10000){
      gasolina--;
      contador=0;
    }
   }
   else
    gasolina = 30; // faz a gasolina voltar ao máximo 

   analog = analogRead(A0); // Lê o potenciometro que simula RPM e Velocidade 
   
   rpm = analog; // Define o valor do RPM igual ao do potenciometro

   velocidade = analog/10; // Da o dado da velocidade como o RPM dividido por 10
  
   if(Serial.available()) // Checa a comunicação serial
  {
    teste = Serial.read(); // Lê a entrada da serial
 
    if(teste == 'y')
      Serial.println(gasolina); // Da a gasolina aos atributos que enviam y   
    
    if(teste == 'x')
      Serial.println(velocidade); // Da a velocidade aos atributos que enviam x

    if(teste == 'z')
      Serial.println(rpm); // Da o RPM aos atributos que enviam z
      
    Serial.flush(); 
  }
}
