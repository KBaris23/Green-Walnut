import pygame 
from sprites import *
from config import *
import sys
import sprites

class Game:
    def __init__(self):
        pygame.init()
        self.screen=pygame.display.set_mode((WIN_WIDTH,WIN_HEIGHT))
        self.clock=pygame.time.Clock()

        self.running=True
    def create_tilemap(self):
        for i, row in enumerate(sprites.tilemap):
            for j, column in enumerate(row):
                if column =='B':
                    Block(self,j,i)
                if column =='.':
                    Grass(self,j,i)
                if column=='E':
                    Enemy(self,j,i)
                if column=='P':
                    Bouncer(self,j,i)
                if column=='S':
                    SettingScreen(self,j,i)
                if column=='p':
                    pit(self,j,i)
                if column=='f':
                    pit1(self,j,i)
    def set_text(self,string, coordx, coordy,size): #Function to set text
        font = pygame.font.SysFont("Segoe UI",size)
    #(0, 0, 0) is black, to make black text
        text = font.render(string, True, (0, 0, 0)) 
        textRect = text.get_rect()
        textRect.center = (coordx, coordy) 
        return (text, textRect)
        

    def new(self):
        self.playing=True
        self.all_sprites=pygame.sprite.LayeredUpdates()
        self.blocks=pygame.sprite.LayeredUpdates()
        self.enemies=pygame.sprite.LayeredUpdates()
        self.attacks=pygame.sprite.LayeredUpdates()
        self.grass=pygame.sprite.LayeredUpdates()
        self.bouncer=pygame.sprite.LayeredUpdates()
        self.arrow=pygame.sprite.LayeredUpdates()
        self.pen=pygame.sprite.LayeredUpdates()
        self.screening=pygame.sprite.LayeredUpdates()
        self.scoring=pygame.sprite.LayeredUpdates()
        self.gameovering=pygame.sprite.LayeredUpdates()
        self.pit=pygame.sprite.LayeredUpdates()
        self.pit1=pygame.sprite.LayeredUpdates()
        left, right, middle=pygame.mouse.get_pressed()
        pygame.display.set_caption('Mouse Pos:')

        
        self.create_tilemap()
        Arrow(self,1,4)
        Pen(self,1,6)
        intro_screening(self,1,3)
        Arrow1(self,28,15)
        score_table(self,5,1)
        gameover(self,1,2)
        next_leveling(self,1,2)
        
    def events(self):
        for event in pygame.event.get():
            if event.type==pygame.QUIT:
                pygame.quit()
                self.playing=False
                self.running=False


    def update(self):
        self.all_sprites.update()
        
    def draw(self):
        self.screen.fill(BLACK)
        self.all_sprites.draw(self.screen)
        #display=pygame.Surface[(640,480)]
        #pygame.draw.line(display,(1,1,50),(1,1),(2,100))
        left,right,middle=pygame.mouse.get_pressed()
        self.clock.tick(FPS)
        pygame.display.flip()
    def main(self):
        while self.playing:
            self.events()#every event like keyboard presses
            self.draw()#draws the dinamic flow of game
            self.update()
            self.set_text("Press to aim",250,250,60)
            left, right, middle=pygame.mouse.get_pressed()
            pygame.display.set_caption('Mouse Pos:')
            if left:

                mx,my=pygame.mouse.get_pos()
            
                self._layer=PLAYER_LAYER
                
                
                MOUSEPOS.append(my)
                MOUSEPOS1.append(mx)
                pos=WIN_WIDTH/2
                if MOUSEPOS1[len(MOUSEPOS)-1]>=pos:
                    pygame.draw.line(self.screen,(0,100,200),(pos,32*(8)),(pos+60,my), width=10)
                if MOUSEPOS1[len(MOUSEPOS)-1]<pos:
                    pygame.draw.line(self.screen,(0,100,200),(pos,32*(8)),(pos-60,my), width=10)
                
                
            for event in pygame.event.get():
                if event.type==pygame.KEYDOWN:
                    if event.key==pygame.K_SPACE:
                        try:
                            if MOUSEPOS[len(MOUSEPOS)-1]>=32*10:
                                pygame.draw.line(self.screen,(0,100,200),(32*10,32*(8)),(100,MOUSEPOS[len(MOUSEPOS)-1]), width=10)
                            if MOUSEPOS[len(MOUSEPOS)-1]<32*10:
                                pygame.draw.line(self.screen,(0,100,200),(32*10,32*(8)),(220,MOUSEPOS[len(MOUSEPOS)-1]), width=10)
                        except:
                            pygame.display.set_caption("an error occured")
                else:
                    if event.type==pygame.KEYDOWN:
                        if event.key==pygame.K_ESCAPE:
                            return 0
                    
            try:
                direction_y=-(MOUSEPOS[(len(MOUSEPOS)-1)]-(32*(8)))
                direction_x=68
                ANGLE=math.atan(direction_y/direction_x)
                VELOCITY_X=math.cos(ANGLE)
                VELOCITY_Y=math.sin(ANGLE)
                pygame.display.set_caption(str(VELOCITY_X))
                BALLDIRECTIONX.insert(0,VELOCITY_X)
                BALLDIRECTIONY.insert(0,VELOCITY_Y)
            except:
                pygame.display.set_caption("an error occured")
            myfont = pygame.font.SysFont("monospace", 15)
            
            # render text
            
            self.set_text("hits left"+str(hits_number),140,140,50)
            
            pygame.display.update()

            #updates frames to keep the game going
        for event in pygame.event.get():
            if event.type== QUIT:
                pygame.quit()
                sys.exit()
        self.running=False

    def game_over(self):
        pass
    def intro_screen(self):
   
         pass
        
g=Game()
g.intro_screen()
g.new()

while g.running:
    g.main()
    g.game_over()
    

pygame.quit()
sys.exit()

