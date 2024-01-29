using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatum
{
    public partial class Form1 : Form
    {

        private static int hexWidth = RenderManager.hexWidth;
        private static int hexHeight = RenderManager.hexHeight;

        public enum_MainActionMode MainActionMode = enum_MainActionMode.Move;


        public Form1()
        {
            InitializeComponent();
            this.creatureRadioButton1.Tag = 0;
            this.creatureRadioButton2.Tag = 1;
            this.creatureRadioButton3.Tag = 2;

            this.radioButtonActionMove.Tag = enum_MainActionMode.Move;
            this.radioButtonActionAttack.Tag = enum_MainActionMode.Attack;

            GameManager.onCurrentPlayerChange += UpdateCreatureRadioButtons;
            GameManager.onCurrentPlayerChange += CurrentCreatureChanged;
            GameManager.onCreatureMove += UpdateHexHighlights;
            GameManager.onCreatureMove += UpdateHasMoveCheckBox;
            GameManager.onCreatureAttack += UpdateHasAttackCheckBox;
            GameManager.onScoreChange += UpdateScoreLabels;
        }

        public enum enum_MainActionMode
        {
            Move,
            Attack
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //init hex field
            Size hexSize = new Size(hexWidth, hexHeight);

            int center_x = 270;
            int center_y = 170;

            double sin30 = 0.5;
            double cos30 = Math.Sqrt(3) / 2;

            double sin60 = cos30;
            double cos60 = sin30;

            int gapWidth = 5;



            foreach(KeyValuePair<Hex, CustomElements.HexButton> kvp in RenderManager.HexButtonDictionary)
            {
                Vec3 cubeCoords = kvp.Key.GetVec3();
                CustomElements.HexButton hexButton = kvp.Value;

                this.Controls.Add(hexButton);
                hexButton.Location = new Point(
                            center_x - hexWidth/2 + ((hexSize.Width) * cubeCoords.x - (int)(((double)((hexSize.Width + gapWidth) * cubeCoords.y + (hexSize.Width + gapWidth) * cubeCoords.z)) * sin30)) / 2
                            , center_y - hexWidth/2 + ((int)(((double)(hexSize.Height + gapWidth) * cubeCoords.y - (hexSize.Height + gapWidth) * cubeCoords.z) * cos30)) * 5 / 9
                            );
                hexButton.Size = hexSize;
                hexButton.Text = cubeCoords.x + ", " + cubeCoords.y + ", " + cubeCoords.z;
                hexButton.onClick_Hex += HexButtonClick;
            }

            //init creature tokens
            Creature creature;
            for (int i = 0; i < GameManager.player1.creatures.Length; i++)
            {
                creature = GameManager.player1.creatures[i];
                if (creature == null) continue;
                CustomElements.CreatureToken token = new CustomElements.CreatureToken(creature);
                token.label = "A" + (i + 1);
            }
            for (int i = 0; i < GameManager.player2.creatures.Length; i++)
            {
                creature = GameManager.player2.creatures[i];
                if (creature == null) continue;
                CustomElements.CreatureToken token = new CustomElements.CreatureToken(creature);
                token.label = "B" + (i + 1);
            }

            foreach (KeyValuePair<Creature,CustomElements.CreatureToken> kvp in RenderManager.CreatureTokenDictionary)
            {
                CustomElements.HexButton button;
                if (!RenderManager.HexButtonDictionary.TryGetValue(kvp.Key.hex, out button)) continue;
                CustomElements.CreatureToken charToken = kvp.Value;
                charToken.Location = button.Location;

                this.Controls.Add(charToken);
                charToken.BringToFront();
            }


            UpdateHexHighlights();
            UpdateCreatureRadioButtons();
            UpdateHasMoveCheckBox();
            UpdateHasAttackCheckBox();
            UpdateScoreLabels();
        }

        private void UpdateCreatureRadioButtons()
        {
            for(int i = 0; i < GameManager.currentPlayer.creatures.Length; i++)
            {
                RadioButton radio = (RadioButton)this.panelCreatureRadioButtons.Controls.Find("creatureRadioButton" + (i + 1), false)[0];
                radio.Text = RenderManager.CreatureTokenDictionary[GameManager.currentPlayer.creatures[i]].label;
                if (GameManager.currentPlayer.creatures[i] == GameManager.currentPlayer.currentCreature)
                {
                    radio.Checked = true;
                }
            }
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            GameManager.ChangeCurrentPlayer();
        }

        private void creatureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                GameManager.currentPlayer.currentCreature = GameManager.currentPlayer.creatures[(int)radioButton.Tag];

                CurrentCreatureChanged();
            }
        }

        private void ResetHexHighlights()
        {
            foreach (Hex hex in HexManager.HexArray)
            {
                RenderManager.HexButtonDictionary[hex].SetState(2);
            }
        }
        private void ResetHexHighlights(Creature creature)
        {
            ResetHexHighlights();
        }

        private void CurrentCreatureChanged()
        {
            UpdateHexHighlights();
            UpdateHasMoveCheckBox();
            UpdateHasAttackCheckBox();
        }

        private void UpdateHasMoveCheckBox()
        {
            this.checkBoxHasMove.Checked = GameManager.currentPlayer.currentCreature.hasMove;
        }
        private void UpdateHasMoveCheckBox(Creature creature)
        {
            UpdateHasMoveCheckBox();
        }
        private void UpdateHasAttackCheckBox()
        {
            this.checkBoxHasAttack.Checked = GameManager.currentPlayer.currentCreature.hasAttack;
        }

        private void radioButtonAction_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                MainActionMode = (enum_MainActionMode)radioButton.Tag;
                                
                MainActionModeChanged();
            }
        }

        private void MainActionModeChanged()
        {
            UpdateHexHighlights();
        }

        private void UpdateHexHighlights()
        {
            ResetHexHighlights();
            switch (MainActionMode)
            {
                case enum_MainActionMode.Move:
                    if (GameManager.currentPlayer.currentCreature.hasMove && GameManager.currentPlayer.currentCreature.hasAttack)
                    {
                        foreach (Hex adjHex in HexManager.GetHexesInRadius_List(GameManager.currentPlayer.currentCreature.hex, 1, HexManager.HexFilterType.UnoccupiedHex))
                        {
                            RenderManager.HexButtonDictionary[adjHex].SetState(1);
                        }
                    }
                    break;
                case enum_MainActionMode.Attack:
                    if (GameManager.currentPlayer.currentCreature.hasMove && GameManager.currentPlayer.currentCreature.hasAttack)
                    {
                        foreach (Hex adjHex in HexManager.GetHexesInLine_list(GameManager.currentPlayer.currentCreature.hex, 2, HexManager.HexFilterType.Enemy))
                        {
                            RenderManager.HexButtonDictionary[adjHex].SetState(1);
                        }
                    }
                    break;
            }
        }
        private void UpdateHexHighlights(Creature creature)
        {
            UpdateHexHighlights();
        }

        private void HexButtonClick(Hex hex)
        {
            switch (MainActionMode)
            {
                case enum_MainActionMode.Move:

                    if (HexManager.GetHexesInRadius_HashSet(GameManager.currentPlayer.currentCreature.hex, 1, HexManager.HexFilterType.UnoccupiedHex).Contains(hex))
                    {
                        GameManager.currentPlayer.currentCreature.Action_Move(hex);
                    }
                    break;
                case enum_MainActionMode.Attack:
                    if (GameManager.GetOpposingPlayer(GameManager.currentPlayer).creatures.Contains(HexManager.HexCreatureDictionary[hex]))
                    {
                        GameManager.currentPlayer.currentCreature.Action_Attack(HexManager.HexCreatureDictionary[hex]);
                    }
                    break;

            }
            UpdateHexHighlights();
        }

        private void UpdateScoreLabels()
        {
            this.player1scoreLabel.Text = GameManager.player1.score.ToString();
            this.player2scoreLabel.Text = GameManager.player2.score.ToString();
        }
    }
}
