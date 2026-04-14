# Space Survival Game (Unity 2D)

## 1. Introduction
Ce projet consiste en le développement d’un jeu vidéo 2D réalisé avec le moteur Unity dans le cadre du cours de Programmation des Jeux. L’objectif est de concevoir un jeu interactif intégrant des mécaniques de survie, de progression et de gestion des ressources.

Le joueur évolue dans un environnement dynamique où il doit éviter des obstacles, collecter des bonus et atteindre des objectifs de score afin de progresser à travers différents niveaux.

---

## 2. Objectifs du projet
- Développer un jeu 2D fonctionnel avec Unity  
- Implémenter un système de déplacement fluide  
- Gérer les collisions et les interactions  
- Mettre en place un système de score évolutif  
- Intégrer des bonus influençant le gameplay  
- Concevoir plusieurs niveaux avec difficulté progressive  
- Créer une interface utilisateur claire  

---

## 3. Description du jeu

### 3.1 Principe
Le joueur contrôle un vaisseau ou un objet volant dans un espace 2D. Des obstacles apparaissent dans la scène et doivent être évités pour survivre. Des bonus sont également présents et permettent d’augmenter les capacités du joueur.

### 3.2 Gameplay
- Déplacement du joueur orienté vers une position cible  
- Accumulation de score en fonction du temps  
- Collecte de bonus donnant des avantages  
- Évitement des obstacles dynamiques  
- Gestion des collisions  

---

## 4. Fonctionnalités

### 4.1 Système de score
- Le score augmente progressivement avec le temps  
- Chaque bonus collecté ajoute des points supplémentaires  
- Le score est affiché en temps réel  

### 4.2 Système de niveaux
Le jeu est structuré en plusieurs niveaux :
- Niveau 1 : 0 à 100 points  
- Niveau 2 : 0 à 200 points  
- Niveau 3 : 0 à 300 points  

À chaque changement de niveau :
- Le score est réinitialisé  
- Le joueur est repositionné à son point de départ  
- La difficulté augmente  

### 4.3 Système de vies (bonus)
- Chaque bonus donne une vie supplémentaire  
- Une collision consomme une vie  
- Le joueur est détruit si les vies atteignent zéro  
- Les vies sont réinitialisées à chaque niveau  

### 4.4 Système de difficulté
- Augmentation significative de la vitesse des obstacles à chaque niveau  
- Progression de la difficulté pour améliorer le challenge  

### 4.5 Interface utilisateur
- Affichage du score en temps réel  
- Affichage du niveau actuel  
- Affichage du nombre de vies  
- Bouton de redémarrage  

---

## 5. Technologies utilisées
- Unity Engine  
- Langage C#  
- UI Toolkit  
- Rigidbody2D (moteur physique)  

---

## 6. Architecture du projet
Le projet est structuré autour de plusieurs composants :
- Scripts de gestion du joueur  
- Gestion des collisions et des bonus  
- Interface utilisateur (UIDocument)  
- Système de progression par niveaux  

---

## 7. Exécution du projet

### 7.1 Depuis Unity
1. Ouvrir Unity Hub  
2. Charger le projet  
3. Ouvrir la scène principale  
4. Lancer le jeu avec le bouton Play  

### 7.2 Version exécutable
Si une version build est disponible :
- Exécuter le fichier .exe  

---

## 8. Gestion de version
Le projet est versionné avec Git et hébergé sur GitHub.  
Les dossiers inutiles générés automatiquement par Unity (Library, Temp, etc.) sont exclus via un fichier .gitignore.

---

## 9. Équipe
- Daniel Kalala Lukusa  
- Eliezer  
- Alexandre  

---

## 10. Perspectives d’amélioration
- Ajout de nouveaux types d’obstacles  
- Intégration d’effets visuels avancés  
- Ajout de sons et musiques  
- Mise en place d’un mode de jeu infini  
- Développement d’un système de score en ligne  

---
