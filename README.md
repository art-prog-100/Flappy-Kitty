# 🐱 Flappy Kitty

Clone do clássico *Flappy Bird*, feito em [Godot Engine](https://godotengine.org/) 4.7 com C#, como projeto de estudo de game dev.

## 🎮 Sobre o jogo

- **Controle:** apenas a barra de **Espaço** — pressione pra fazer o personagem pular.
- **Objetivo:** desviar dos obstáculos e sobreviver o máximo possível.

## 🛠️ Tecnologias

- **Engine:** Godot 4.7.1 (Mono/.NET)
- **Linguagem:** C# (.NET 8)

## 📁 Estrutura do projeto

```
flappy-kitty/
├── cenas/               # Cenas do Godot (.tscn)
├── codes/               # Scripts em C#
├── sprites/              # Imagens e spritesheets
├── project.godot        # Arquivo de configuração do Godot
├── Flappy Kitty.csproj  # Projeto C#/.NET
└── Flappy Kitty.sln     # Solution do Visual Studio/VS Code
```

> Obs: o projeto ainda não tem um ícone customizado (`icon.svg` foi removido). O Godot usa o ícone padrão da engine até que um novo seja adicionado.

## ▶️ Como rodar

1. Instale o [Godot Engine 4.7+ (.NET/Mono)](https://godotengine.org/download)
2. Clone este repositório
3. Abra o Godot, clique em **"Importar"** e selecione o arquivo `project.godot`
4. Rode o projeto (F5)

## ✅ Status atual

- [x] Movimento por gravidade
- [x] Pulo com cooldown
- [ ] Geração de obstáculos (canos)
- [ ] Sistema de pontuação
- [ ] Tela de game over
- [ ] Ícone customizado
- [ ] Sprites e animações finais

## 📝 Licença

Projeto pessoal de estudo, sem licença definida ainda.
