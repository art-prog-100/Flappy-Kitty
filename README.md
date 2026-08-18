# 🐱 Flappy Kitty

Clone do clássico *Flappy Bird*, feito em [Godot Engine](https://godotengine.org/) 4.7 com C#, como projeto de estudo de game dev.

## 🎮 Sobre o jogo

- **Controle:** apenas a barra de **Espaço** — pressione pra fazer o personagem pular.
- **Objetivo:** desviar dos canos e sobreviver o máximo possível.

## 🛠️ Tecnologias

- **Engine:** Godot 4.7.1 (Mono/.NET)
- **Linguagem:** C# (.NET 8)

## 📁 Estrutura do projeto

```
flappy-kitty/
├── cenas/               # Cenas do Godot (.tscn)
│   ├── node_2d.tscn      # Cena principal (jogador, cenário, spawner)
│   └── cano.tscn         # Cena do par de canos (obstáculo)
│   ├── game_over.tscn    # Cena prototipo para quando o jogador perder
│   └── menu.tscn         # Cena de inicio do jogo
├── codes/                # Scripts em C#
│   ├── CharacterBody2d.cs   # Movimento, pulo, limites de tela e game over
│   ├── Cano.cs               # Movimento e auto-destruição do cano
│   └── CanoSpawner.cs        # Geração procedural dos canos
│   ├── ChaoScroll.cs         # Movimento do chao do cenario
│   ├── GameOver.cs           # codigo para os botões do game over     
│   └── Menu.cs               # codigo inicial menu
├── fonts/              # fontes de texto personalizadas para o jogo
├── sprites/              # Imagens e spritesheets
├── project.godot         # Arquivo de configuração do Godot
├── Flappy Kitty.csproj    # Projeto C#/.NET
└── Flappy Kitty.sln       # Solution do Visual Studio/VS Code
```

## ▶️ Como rodar

1. Instale o [Godot Engine 4.7+ (.NET/Mono)](https://godotengine.org/download)
2. Clone este repositório
3. Abra o Godot, clique em **"Importar"** e selecione o arquivo `project.godot`
4. Rode o projeto (F5)

## ✅ Status atual

- [x] Movimento por gravidade
- [x] Pulo com cooldown
- [x] Geração procedural dos canos (posição vertical sorteada, largura de abertura fixa)
- [x] Auto-destruição dos canos ao saírem da tela (evita vazamento de nós)
- [x] Limite vertical de tela (jogador não sai por cima; cair demais gera game over)
- [x] Detecção de colisão jogador x canos (via `Area2D` + camadas de colisão separadas)
- [x] Game over (congela a cena e toca animação de "hit")
- [x] Reiniciar o jogo após o game over
- [x] Sistema de pontuação
- [ ] Tela/UI de game over
- [ ] Ícone customizado
- [ ] Sprites e animações finais
- [x] Ajuste de dificuldade progressiva (velocidade/abertura dos canos)

## 🧠 Decisões técnicas

- **Jogador parado, mundo se movendo:** o `CharacterBody2D` não se desloca no eixo X — canos e fundo é que rolam para a esquerda. Simplifica spawn/despawn e o parallax do cenário.
- **Camadas de colisão:** o `Area2D` do jogador está na *mask* 2 (obstáculos) e os canos na *layer* 2, evitando que o jogador detecte a própria hitbox (bug que travava o jogo assim que abria).
- **`GetTree().Paused = true`** é usado para o game over, pois congela automaticamente jogador, canos e o spawner sem precisar controlar cada um manualmente.

## 📝 Licença

Projeto pessoal de estudo, sem licença definida ainda.
