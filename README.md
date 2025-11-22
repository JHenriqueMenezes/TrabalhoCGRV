# Space Shooter - Computação Gráfica e Realidade Virtual

**Universidade de Passo Fundo - UPF**  
**Disciplina:** Computação Gráfica e Realidade Virtual  
**Professor:** Rafael Rieder  
**Ano:** 2025  

## 👨‍💻 Desenvolvedores
- **João Henrique Menezes de Souza** - 125252
- **Diogo Brollo** - 197421
- **Guilherme Vieira** - 111111

---

## 🚀 Sobre o Jogo
Um Space Shooter clássico desenvolvido como trabalho final da disciplina. O jogador controla uma nave espacial e deve sobreviver a ondas de inimigos e obstáculos enquanto avança pelo espaço.

### 🎯 Objetivo
Para vencer, o jogador deve cumprir três condições simultaneamente:
1. **Sobreviver:** Não ser destruído pelos inimigos ou obstáculos.
2. **Derrotar Inimigos:** Eliminar uma quantidade mínima de inimigos.
3. **Alcançar a Meta:** Chegar a uma distância Y específica antes que o tempo acabe.

> **Nota:** O tempo limite e a quantidade de inimigos necessários são ajustados dinamicamente pelo sistema de dificuldade.

### 🎮 Controles
| Ação | Tecla |
| :--- | :--- |
| **Movimentação** | WASD |
| **Atirar** | Botão esquerdo do mouse |

---

## 🛠️ Funcionalidades e Estado do Projeto

### ✅ Implementado

#### 🕹️ Mecânicas de Jogo (Gameplay)
- **Movimentação do Jogador**
- **Sistema de Combate**
  - **Disparo Contínuo**
  - **Projéteis** 
  - **Dano e Vida**
  - **Feedback Visual/Sonoro**
  - **Camera Shake**
- **Inimigos**
  - **Movimentação**
  - **Spawner**

#### ⚙️ Sistemas e Gerenciadores
- **Condição de Vitória**
- **Dificuldade Dinâmica**
- **Sistema de Pontuação**
- **Ambiente**
  - **Background Infinito**
  - **Gerenciamento de Cenas**

### 📝 Roadmap (TODO)
- [✅] **Placar (Highscores):**
    - UI dedicada para o Placar.
    - Armazenamento dos 5 melhores scores.
    - Fórmula de pontuação: `((Tempo Restante * 10) * Inimigos Derrotados) * Multiplicador de Dificuldade`.
- [✅] **Efeitos Sonoros UI:** Adicionar sons de feedback para botões e interações no menu.
- [✅] **Movimentação do Player:** Ajustes finos na física e resposta dos controles.
- [✅] **Meteoros:** Implementar movimentação fixa/padronizada para os obstáculos.
- [✅] **Menu de Pause:** Criar interface e lógica para pausar o jogo.
- [❌] **HUD In-Game:** Melhorar a visualização de vida, tempo e score durante a partida.
- [✅] **Power-ups:** Coletável que aumenta o tempo restante (com limite de spawn).
- [✅] **"IA" Inimiga:** Ajustar naves inimigas para atirarem contra o jogador.

---

## 🎨 Créditos e Assets
Recursos de terceiros utilizados no projeto:

- **Planetas:** [Kenney Assets - Planets](https://kenney.nl/assets/planets)
- **Efeitos Sonoros (SFX):** [Kenney Assets - Sci-Fi Sounds](https://kenney.nl/assets/sci-fi-sounds)
- **Música:** [OpenGameArt - 5 Chiptunes Action](https://opengameart.org/content/5-chiptunes-action)
- **Fontes:** [DaFont - Aldo the Apache](https://www.dafont.com/aldo-the-apache.font)

---

## 🔗 Links
- **Build do Jogo:** [https://drive.google.com/file/d/1fpR2ptdRf1Pz3-3CoWUNwVXEEUAcQtny/view?usp=drive_link]
- **Vídeo de Gameplay:** [Inserir Link Aqui]
- **Documentação do Trabalho:** [Trabalho_Pratico_CG_2025.pdf](Trabalho_Pratico_CG_2025.pdf)
