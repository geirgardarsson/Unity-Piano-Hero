import midi
import argparse


parser = argparse.ArgumentParser()
parser.add_argument('midi_file')

args = parser.parse_args()

song = midi.read_midifile(args.midi_file)
song.make_ticks_abs()

tracks = []

for track in song:
    notes = [note for note in track if note.name == 'Note On']
    pitch = [note.pitch for note in notes]
    tracks += [pitch]

print(song[1])

#print(tracks)
#print(len(tracks))

